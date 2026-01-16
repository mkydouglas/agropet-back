using Agropet.Application.Common.Response;
using Agropet.Application.Produto.Queries;
using Agropet.Application.Produto.Responses;
using Agropet.Domain.Interfaces;
using MediatR;
using System.Net;

namespace Agropet.Application.Produto.Handlers;

public sealed class ProdutoQueryHandlers : IRequestHandler<ListarProdutosQuery, Resposta>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoQueryHandlers(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Resposta> Handle(ListarProdutosQuery request, CancellationToken cancellationToken)
    {
        var produtos = await _produtoRepository.ListarAsync();
        var response = produtos.Select(p => new ListarProdutoResponse
        {
            Id = p.Id,
            Nome = p.Nome,
            Codigo = p.Codigo,
            CodigoBarras = p.CodigoBarras,
            Margem = p.Margem,
            PrecoVenda = p.PrecoVenda,
            UnidadeComercial = p.UnidadeComercial,
            QuantidadeProduto = p.EstoqueProdutos.First().QuantidadeProduto,
            NomeFantasiaFornecedores = p.FornecedorProdutos.Where(fp => fp.Fornecedor != null && fp.Fornecedor.NomeFantasia != null).Select(fp => fp.Fornecedor.NomeFantasia!).ToList()
        });
        //TODO: rever itens que precisam ser retornados
        return new Resposta((int)HttpStatusCode.OK, response);
    }
}
