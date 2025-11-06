using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Agropet.Application.Response;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Services;

public class VendaService : ServiceBase<Venda>, IVendaService
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IProdutoVendaService _produtoVendaService;
    private readonly IVendaFormaPagamentoService _vendaFormaPagamentoService;
    private readonly IMovimentacaoEstoqueService _movimentacaoEstoqueService;

    public VendaService(
        IVendaRepository vendaRepository, 
        IProdutoVendaService produtoVendaService, 
        IVendaFormaPagamentoService vendaFormaPagamentoService, 
        IMovimentacaoEstoqueService movimentacaoEstoqueService) : base(vendaRepository)
    {
        _vendaRepository = vendaRepository;
        _produtoVendaService = produtoVendaService;
        _vendaFormaPagamentoService = vendaFormaPagamentoService;
        _movimentacaoEstoqueService = movimentacaoEstoqueService;
    }

    public async Task<Resposta> Cadastrar(VendaDTO vendaDTO)
    {
        if (vendaDTO == null || vendaDTO.ProdutoVendaDTOs == null || vendaDTO.VendaFormaPagamentoDTOs == null)
            return new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Por favor, envie os produtos vendidos");

        var venda = await _vendaRepository.CriarTeste((Venda)vendaDTO);
        var produtoVendas = vendaDTO.ProdutoVendaDTOs.Select(pv => (ProdutoVenda)pv).ToList();
        foreach (var item in produtoVendas)
        {
            item.IdVenda = venda.Id;
        }

        var vendaFormaPagamento = vendaDTO.VendaFormaPagamentoDTOs.Select(vf => (VendaFormaPagamento)vf).ToList();
        foreach (var item in vendaFormaPagamento)
        {
            item.IdVenda = venda.Id;
        }

        foreach (var item in produtoVendas)
        {
            _produtoVendaService.Criar(item);
            _movimentacaoEstoqueService.Criar(new MovimentacaoEstoque
            {
                ETipoMovimentacaoEstoque = Domain.Enums.ETipoMovimentacaoEstoque.Saida,
                Quantidade = item.Quantidade,
                IdProduto = item.IdProduto,
            });
        }

        foreach (var item in vendaFormaPagamento)
        {
            _vendaFormaPagamentoService.Criar(item);
        }

        return new Resposta((int)HttpStatusCode.OK);
    }
}
