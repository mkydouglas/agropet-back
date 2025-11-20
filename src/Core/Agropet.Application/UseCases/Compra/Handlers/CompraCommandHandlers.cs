using Agropet.Application.Helpers;
using Agropet.Application.Response;
using Agropet.Application.UseCases.Compra.Commands;
using Agropet.Application.UseCases.Fornecedor.Commands;
using Agropet.Application.UseCases.Fornecedor.Queries;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Domain.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Agropet.Application.UseCases.Compra.Handlers;

public sealed class CadastrarCompraCommandHandler : IRequestHandler<CadastrarCompraCommand, Resposta>
{
    private readonly ICompraRepository _compraRepository;
    private readonly IItemCompraRepository _itemCompraRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IProdutoRepository _produtoRepository;

    public CadastrarCompraCommandHandler(ICompraRepository compraRepository, IItemCompraRepository itemCompraRepository, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IFornecedorRepository fornecedorRepository, IProdutoRepository produtoRepository)
    {
        _compraRepository = compraRepository;
        _itemCompraRepository = itemCompraRepository;
        _unitOfWork = unitOfWork;
        _usuarioRepository = usuarioRepository;
        _fornecedorRepository = fornecedorRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<Resposta> Handle(CadastrarCompraCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObterAsync(request.IdUsuario);
        var fornecedor = await _fornecedorRepository.ObterAsync(request.IdFornecedor);

        if (usuario == null || fornecedor == null)
            return new Resposta((int)HttpStatusCode.BadRequest, false, "Erro");

        var compra = new Domain.Entities.Compra(request.NumeroNotaFiscal, usuario, fornecedor);

        var idsProdutos = request.ItensComprados.Select(ic => ic.IdProduto).ToList();
        var produtos = await _produtoRepository.ListarPorIdsAsync(idsProdutos);

        foreach (var item in request.ItensComprados)
        {
            compra.AdicionarItem(item.Quantidade, item.Preco, produtos[item.IdProduto]);
        }

        _compraRepository.Criar(compra);
        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.Created);
    }
}

public sealed class CadastrarCompraViaNFCommandHandler : IRequestHandler<CadastrarCompraViaNFCommand, Resposta>
{
    private readonly ICompraRepository _compraRepository;
    private readonly IItemCompraRepository _itemCompraRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMediator _mediator;

    public CadastrarCompraViaNFCommandHandler(ICompraRepository compraRepository, IItemCompraRepository itemCompraRepository, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IFornecedorRepository fornecedorRepository, IProdutoRepository produtoRepository, IMediator mediator)
    {
        _compraRepository = compraRepository;
        _itemCompraRepository = itemCompraRepository;
        _unitOfWork = unitOfWork;
        _usuarioRepository = usuarioRepository;
        _fornecedorRepository = fornecedorRepository;
        _produtoRepository = produtoRepository;
        _mediator = mediator;
    }

    public async Task<Resposta> Handle(CadastrarCompraViaNFCommand request, CancellationToken cancellationToken)
    {
        var nota = XMLHelper.LerNF(request.Stream);

        if (nota == null)
            return new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Nota Fiscal não processada.");

        //como obter da nota:
        //fornecedor
        var f = nota.NFe.InfNFe.Emitente;
        //produtos
        var ps = nota.NFe.InfNFe.InfoProduto;
        //produto
        var p = nota.NFe.InfNFe.InfoProduto[0].Produto;
        //lote
        var l = nota.NFe.InfNFe.InfoProduto[0].Produto.Rastro;

        Domain.Entities.Fornecedor? fornecedor;
        //opção 1:
        var obterFornecedor = await _mediator.Send(new ObterFornecedorPorCNPJQuery(nota.NFe.InfNFe.Emitente.CNPJ));
        if(obterFornecedor.Data == null)
        {
            var cadastrarFornecedor = await _mediator.Send(new CadastrarFornecedorCommand());
            fornecedor = JsonSerializer.Deserialize<Domain.Entities.Fornecedor>(cadastrarFornecedor.Data.ToString());
        }

        //opção 2:
        fornecedor = _fornecedorRepository.ObterPorCnpj(nota.NFe.InfNFe.Emitente.CNPJ);


        var compra = new Domain.Entities.Compra(nota.NFe.InfNFe.NumeroNF, new(), new());
        

        return new Resposta((int)HttpStatusCode.Created);
    }
}
