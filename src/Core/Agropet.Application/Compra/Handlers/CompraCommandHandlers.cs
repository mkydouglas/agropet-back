using Agropet.Application._Common.DTOs;
using Agropet.Application.Common.Helpers;
using Agropet.Application.Common.Interfaces;
using Agropet.Application.Common.Response;
using Agropet.Application.Compra.Commands;
using Agropet.Application.Compra.Inputs;
using Agropet.Application.Compra.Services;
using Agropet.Domain.Interfaces;
using Agropet.Domain.Models;
using Mapster;
using MediatR;
using System.Net;

namespace Agropet.Application.Compra.Handlers;

public sealed class CadastrarCompraCommandHandler : IRequestHandler<CadastrarCompraCommand, Resposta>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IEstoqueRepository _estoqueRepository;
    private readonly IFornecedorService _fornecedorService;
    private readonly IProcessadorCompra _processadorCompra;

    public CadastrarCompraCommandHandler(IUsuarioRepository usuarioRepository, IEstoqueRepository estoqueRepository, IFornecedorService fornecedorService, IProcessadorCompra processadorCompra)
    {
        _usuarioRepository = usuarioRepository;
        _estoqueRepository = estoqueRepository;
        _fornecedorService = fornecedorService;
        _processadorCompra = processadorCompra;
    }

    public async Task<Resposta> Handle(CadastrarCompraCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObterAsync(request.UserId!.Value);
        if (usuario == null)
            return new Resposta((int)HttpStatusCode.BadRequest, false, "Erro ao processar compra.");

        var fornecedor = await _fornecedorService.GarantirExistenciaAsync(request.FornecedorInput.Adapt<FornecedorDTO>(), usuario.Id);
        var estoque = await _estoqueRepository.ObterAsync(1);

        if (fornecedor == null || estoque == null)
            return new Resposta((int)HttpStatusCode.BadRequest, false, "Erro ao processar compra.");

        var cadastrarCompraInput = new CadastrarCompraInput(request.NumeroNotaFiscal, fornecedor, request.ItensComprados, usuario, estoque);
        await _processadorCompra.ProcessarAsync(cadastrarCompraInput, cancellationToken);

        return new Resposta((int)HttpStatusCode.Created);
    }
}

public sealed class CadastrarCompraViaNFCommandHandler : IRequestHandler<CadastrarCompraViaNFCommand, Resposta>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IEstoqueRepository _estoqueRepository;
    private readonly IFornecedorService _fornecedorService;
    private readonly IProcessadorCompra _processadorCompra;

    public CadastrarCompraViaNFCommandHandler(IUsuarioRepository usuarioRepository, IEstoqueRepository estoqueRepository, IFornecedorService fornecedorService, IProcessadorCompra processadorCompra)
    {
        _usuarioRepository = usuarioRepository;
        _estoqueRepository = estoqueRepository;
        _fornecedorService = fornecedorService;
        _processadorCompra = processadorCompra;
    }

    public async Task<Resposta> Handle(CadastrarCompraViaNFCommand request, CancellationToken cancellationToken)
    {
        var nota = XMLHelper.LerNF(request.Stream);

        if (nota == null)
            return new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Erro ao processar Nota Fiscal enviada.");

        var nf = nota.NFe.InfNFe;

        var usuario = await _usuarioRepository.ObterAsync(request.UserId!.Value);
        if (usuario == null)
            return new Resposta((int)HttpStatusCode.BadRequest, false, "Erro ao processar Nota Fiscal enviada");

        var fornecedor = await _fornecedorService.GarantirExistenciaAsync(nf.Emitente.Adapt<FornecedorDTO>(), usuario!.Id);
        var estoque = await _estoqueRepository.ObterAsync(1);

        if (fornecedor == null || estoque == null)
            throw new();

        var itens = nf.InfoProduto
            .Select(i => new ItemCompraInput
            {
                ProdutoInput = i.Produto.Adapt<ProdutoInput>(),
                LoteInput = i.Produto.Rastro.Adapt<LoteInput>(),
                PrecoUnitario = i.Produto.ValorUnidadeComercial,
                Quantidade = int.Parse(i.Produto.QuantidadeComercial)
            }            )
            .ToList();

        await _processadorCompra.ProcessarAsync(new CadastrarCompraInput(nf.NumeroNF, fornecedor, itens, usuario, estoque), cancellationToken);

        return new Resposta((int)HttpStatusCode.Created);
    }    
}
