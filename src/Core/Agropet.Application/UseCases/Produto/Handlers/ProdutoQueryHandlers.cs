using Agropet.Application.Response;
using Agropet.Application.UseCases.Produto.Queries;
using Agropet.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Produto.Handlers;

public sealed class ProdutoQueryHandlers : IRequestHandler<ListarProdutosQuery, Resposta>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoQueryHandlers(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public Task<Resposta> Handle(ListarProdutosQuery request, CancellationToken cancellationToken)
    {
        var produtos = _produtoRepository.Listar();
        //TODO: rever itens que precisam ser retornados
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, produtos));
    }
}
