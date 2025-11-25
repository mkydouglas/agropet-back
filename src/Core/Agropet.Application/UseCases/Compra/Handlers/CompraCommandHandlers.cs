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

        var compra = new Domain.Entities.Compra(request.NumeroNotaFiscal, usuario, fornecedor, 0);

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
    private readonly ILoteRepository _loteRepository;

    public CadastrarCompraViaNFCommandHandler(ICompraRepository compraRepository, IItemCompraRepository itemCompraRepository, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IFornecedorRepository fornecedorRepository, IProdutoRepository produtoRepository, IMediator mediator, ILoteRepository loteRepository)
    {
        _compraRepository = compraRepository;
        _itemCompraRepository = itemCompraRepository;
        _unitOfWork = unitOfWork;
        _usuarioRepository = usuarioRepository;
        _fornecedorRepository = fornecedorRepository;
        _produtoRepository = produtoRepository;
        _mediator = mediator;
        _loteRepository = loteRepository;
    }

    public async Task<Resposta> Handle(CadastrarCompraViaNFCommand request, CancellationToken cancellationToken)
    {
        var nota = XMLHelper.LerNF(request.Stream);

        if (nota == null)
            return new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Nota Fiscal não processada.");

        var nf = nota.NFe.InfNFe;

        var fornecedor = await GarantirExistenciaAsync(nota.NFe.InfNFe.Emitente);

        ////é necessário salvar cada item (produto) da compra
        
        var codigoBarrasProdutos = nf.InfoProduto.Select(i => i.Produto.CodigoBarras).ToList();
        var produtosExistentes = await _produtoRepository.ListarPorCodigoBarrasAsync(codigoBarrasProdutos);

        var nlotes = nf.InfoProduto.Select(i => i.Produto.Rastro.NLote.ToLower()).Distinct().ToList();
        var lotesExistentes = await _loteRepository.ListarPorNumeroAsync(nlotes);

        //se o produto já existir na base, deve ser criado um novo lote ou atualizado caso já exista
        foreach (var produto in produtosExistentes)
        {
            //produto e produxml não são a mesma coisa?
            var produtoXml = nf.InfoProduto.First(i => i.Produto.CodigoBarras == produto.CodigoBarras);

            var loteExistente = lotesExistentes[produtoXml.Produto.Rastro.NLote];

            if(loteExistente == null)
            {
                //cria o novo lote
                var novoLote = produtoXml.Produto.Rastro.Adapt<Domain.Entities.Lote>();
                novoLote.ReferenciarProduto(produtoXml.Produto.Adapt<Domain.Entities.Produto>());
                _loteRepository.Criar(novoLote);
            }
        }

        //se não existir, cria um novo produto e o lote correspondente
        var novosProdutos = nf.InfoProduto.Select(i => i.Produto).Where(p => produtosExistentes.All(e => e.CodigoBarras != p.CodigoBarras)).ToList();

        foreach (var produtoXml in novosProdutos)
        {
            var produto = produtoXml.Adapt<Domain.Entities.Produto>();
            _produtoRepository.Criar(produto);
            var novoLote = produtoXml.Rastro.Adapt<Domain.Entities.Lote>();
            novoLote.ReferenciarProduto(produto);
            _loteRepository.Criar(novoLote);
            produtosExistentes.Add(produto);
        }

        //TODO: falta valor total -- ajustar na extração do xml tb
        var compra = new Domain.Entities.Compra(nota.NFe.InfNFe.NumeroNF, new(), fornecedor, nota.NFe.InfNFe.InfoProduto.Count);

        foreach(var produto in produtosExistentes)
        {
            compra.AdicionarItem(0, 0, produto);
        }

        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.Created);
    }

    private async Task<Domain.Entities.Fornecedor> GarantirExistenciaAsync(Emitente emitente)
    {
        var fornecedor = _fornecedorRepository.ObterPorCnpj(emitente.CNPJ);
        if (fornecedor == null)
            fornecedor = _fornecedorRepository.Criar(emitente.Adapt<Domain.Entities.Fornecedor>());

        return fornecedor;
    }

    
}
