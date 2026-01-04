using Agropet.Application.Helpers;
using Agropet.Application.Response;
using Agropet.Application.UseCases.Compra.Commands;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Domain.Models;
using Mapster;
using MediatR;
using System.Net;

namespace Agropet.Application.UseCases.Compra.Handlers;

public sealed class CadastrarCompraCommandHandler : IRequestHandler<CadastrarCompraCommand, Resposta>
{
    private readonly ICompraRepository _compraRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IEstoqueRepository _estoqueRepository;
    private readonly ILoteRepository _loteRepository;

    public CadastrarCompraCommandHandler(ICompraRepository compraRepository, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IFornecedorRepository fornecedorRepository, IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository, ILoteRepository loteRepository)
    {
        _compraRepository = compraRepository;
        _unitOfWork = unitOfWork;
        _usuarioRepository = usuarioRepository;
        _fornecedorRepository = fornecedorRepository;
        _produtoRepository = produtoRepository;
        _estoqueRepository = estoqueRepository;
        _loteRepository = loteRepository;
    }

    public async Task<Resposta> Handle(CadastrarCompraCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.ObterAsync(request.UserId!.Value);
        var fornecedor = await GarantirExistenciaAsync(request.FornecedorDTO, usuario!.Id);
        var estoque = await _estoqueRepository.ObterAsync(1);

        if (usuario == null || fornecedor == null || estoque == null)
            return new Resposta((int)HttpStatusCode.BadRequest, false, "Erro");

        var compra = new Domain.Entities.Compra(request.NumeroNotaFiscal, usuario, fornecedor, request.ItensComprados.Count);

        var idsProdutos = request.ItensComprados.Select(i => i.ProdutoDTO.Id.GetValueOrDefault()).Where(id => id != 0).ToList();
        var produtosExistentes = await _produtoRepository.ListarPorIdsAsync(idsProdutos);

        var nlotes = request.ItensComprados.Select(i => i.ProdutoDTO.LoteDTO?.Numero?.ToLower()).Distinct().ToList();
        var lotesExistentes = await _loteRepository.ListarPorNumeroAsync(nlotes);

        foreach (var produto in produtosExistentes)
        {
            var produtoXml = request.ItensComprados.First(i => i.ProdutoDTO.CodigoBarras == produto.CodigoBarras);
            var quantidade = produtoXml.ProdutoDTO.Quantidade;
            var valorTotal = produto.PrecoUnitarioCompra * quantidade;
            compra.SomarAoValorTotal(valorTotal);

            produto
                .CalcularPrecoVenda(0.4)
                .ReferenciarFornecedor(fornecedor)
                .ReferenciarEstoque(estoque, quantidade)
                .AdicionarItem(quantidade, valorTotal, compra);

            _produtoRepository.Atualizar(produto);

            var loteExistente = lotesExistentes[produtoXml.ProdutoDTO.LoteDTO.Numero];
            if (loteExistente == null)
            {
                //cria o novo lote
                var novoLote = produtoXml.ProdutoDTO.LoteDTO.Adapt<Domain.Entities.Lote>();
                novoLote.ReferenciarProduto(produto);
                _loteRepository.Criar(novoLote);
            }
            else
            {
                loteExistente.AtualizarQuantidade(quantidade);
                _loteRepository.Atualizar(loteExistente);
            }
        }

        var novosProdutos = request.ItensComprados.Where(p => p.ProdutoDTO.Id == null).ToList();

        foreach (var produtoXml in novosProdutos)
        {
            var produto = produtoXml.ProdutoDTO.Adapt<Domain.Entities.Produto>();
            var quantidade = produtoXml.ProdutoDTO.Quantidade;
            var valorTotal = produto.PrecoUnitarioCompra * quantidade;
            compra.SomarAoValorTotal(valorTotal);

            produto
                .CalcularPrecoVenda(0.4)
                .ReferenciarUsuario(usuario)
                .ReferenciarFornecedor(fornecedor)
                .ReferenciarEstoque(estoque, quantidade)
                .AdicionarItem(quantidade, valorTotal, compra);

            _produtoRepository.Criar(produto);

            var novoLote = produtoXml.ProdutoDTO.LoteDTO.Adapt<Domain.Entities.Lote>();
            if (novoLote == null)
                continue;

            novoLote.ReferenciarProduto(produto);
            _loteRepository.Criar(novoLote);
        }

        _compraRepository.Criar(compra);
        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.Created);
    }

    private async Task<Domain.Entities.Fornecedor> GarantirExistenciaAsync(FornecedorDTO emitente, int idUsuario)//trocar emitente por fornecedorDTO
    {
        var fornecedor = _fornecedorRepository.ObterPorCnpj(emitente.CNPJ);
        if (fornecedor == null)
        {
            fornecedor = emitente.Adapt<Domain.Entities.Fornecedor>();
            fornecedor.IdUsuario = idUsuario;
            fornecedor = _fornecedorRepository.Criar(fornecedor);
        }

        return fornecedor;
    }
    private async Task<Domain.Entities.Fornecedor> GarantirExistenciaAsync(Emitente emitente, int idUsuario)
    {
        var fornecedor = _fornecedorRepository.ObterPorCnpj(emitente.CNPJ);
        if (fornecedor == null)
        {
            fornecedor = emitente.Adapt<Domain.Entities.Fornecedor>();
            fornecedor.IdUsuario = idUsuario;
            fornecedor = _fornecedorRepository.Criar(fornecedor);
        }

        return fornecedor;
    }
}

public sealed class CadastrarCompraViaNFCommandHandler : IRequestHandler<CadastrarCompraViaNFCommand, Resposta>
{
    private readonly ICompraRepository _compraRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly ILoteRepository _loteRepository;
    private readonly IEstoqueRepository _estoqueRepository;

    public CadastrarCompraViaNFCommandHandler(ICompraRepository compraRepository, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IFornecedorRepository fornecedorRepository, IProdutoRepository produtoRepository, ILoteRepository loteRepository, IEstoqueRepository estoqueRepository)
    {
        _compraRepository = compraRepository;
        _unitOfWork = unitOfWork;
        _usuarioRepository = usuarioRepository;
        _fornecedorRepository = fornecedorRepository;
        _produtoRepository = produtoRepository;
        _loteRepository = loteRepository;
        _estoqueRepository = estoqueRepository;
    }

    public async Task<Resposta> Handle(CadastrarCompraViaNFCommand request, CancellationToken cancellationToken)
    {
        var nota = XMLHelper.LerNF(request.Stream);

        if (nota == null)
            return new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Nota Fiscal não processada.");

        var nf = nota.NFe.InfNFe;

        var usuario = await _usuarioRepository.ObterAsync(request.UserId!.Value);
        var fornecedor = await GarantirExistenciaAsync(nf.Emitente, usuario!.Id);
        var estoque = await _estoqueRepository.ObterAsync(1);

        if (usuario == null || estoque == null)
            throw new();

        ////é necessário salvar cada item (produto) da compra
        var compra = new Domain.Entities.Compra(nf.NumeroNF, usuario, fornecedor, nf.InfoProduto.Count, nf.Total.ICMSTot.ValorNF);
        _compraRepository.Criar(compra);
        
        var codigoBarrasProdutos = nf.InfoProduto.Select(i => i.Produto.CodigoBarras).ToList();
        var produtosExistentes = await _produtoRepository.ListarPorCodigoBarrasAsync(codigoBarrasProdutos);

        var nlotes = nf.InfoProduto.Select(i => i.Produto.Rastro.NLote.ToLower()).Distinct().ToList();
        var lotesExistentes = await _loteRepository.ListarPorNumeroAsync(nlotes);

        //se o produto já existir na base, deve ser criado um novo lote ou atualizado caso já exista
        foreach (var produto in produtosExistentes)
        {
            var produtoXml = nf.InfoProduto.First(i => i.Produto.CodigoBarras == produto.CodigoBarras).Produto;
            var quantidade = int.Parse(produtoXml.QuantidadeComercial);

            produto
                .CalcularPrecoVenda(0.4)
                .ReferenciarFornecedor(fornecedor)
                .ReferenciarEstoque(estoque, quantidade)
                .AdicionarItem(quantidade, produtoXml.ValorTotal, compra);

            _produtoRepository.Atualizar(produto);

            var loteExistente = lotesExistentes[produtoXml.Rastro.NLote];
            if(loteExistente == null)
            {
                //cria o novo lote
                var novoLote = produtoXml.Rastro.Adapt<Domain.Entities.Lote>();
                novoLote.ReferenciarProduto(produto);
                _loteRepository.Criar(novoLote);
            }
            else
            {
                loteExistente.AtualizarQuantidade(quantidade);
                _loteRepository.Atualizar(loteExistente);
            }
        }

        //se não existir, cria um novo produto e o lote correspondente
        var novosProdutos = nf.InfoProduto.Select(i => i.Produto).Where(p => produtosExistentes.All(e => e.CodigoBarras != p.CodigoBarras)).ToList();

        foreach (var produtoXml in novosProdutos)
        {
            var produto = produtoXml.Adapt<Domain.Entities.Produto>();
            var quantidade = int.Parse(produtoXml.QuantidadeComercial);
            produto
                .CalcularPrecoVenda(0.4)
                .ReferenciarUsuario(usuario)
                .ReferenciarFornecedor(fornecedor)
                .ReferenciarEstoque(estoque, quantidade)
                .AdicionarItem(quantidade, produtoXml.ValorTotal, compra);
            
            _produtoRepository.Criar(produto);

            var novoLote = produtoXml.Rastro.Adapt<Domain.Entities.Lote>();
            novoLote.ReferenciarProduto(produto);
            _loteRepository.Criar(novoLote);
        }

        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.Created);
    }

    private async Task<Domain.Entities.Fornecedor> GarantirExistenciaAsync(Emitente emitente, int idUsuario)
    {
        var fornecedor = _fornecedorRepository.ObterPorCnpj(emitente.CNPJ);
        if (fornecedor == null)
        {
            fornecedor = emitente.Adapt<Domain.Entities.Fornecedor>();
            fornecedor.IdUsuario = idUsuario;
            fornecedor = _fornecedorRepository.Criar(fornecedor);
        }

        return fornecedor;
    }

    
}
