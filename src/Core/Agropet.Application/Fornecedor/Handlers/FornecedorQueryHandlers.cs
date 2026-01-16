using Agropet.Application.Common.Response;
using Agropet.Application.Fornecedor.Queries;
using Agropet.Application.Fornecedor.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System.Net;

namespace Agropet.Application.Fornecedor.Handlers;

public sealed class ListarFornecedorQueryHandler : IRequestHandler<ListarFornecedorQuery, Resposta>
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public ListarFornecedorQueryHandler(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public Task<Resposta> Handle(ListarFornecedorQuery request, CancellationToken cancellationToken)
    {
        var fornecedores = _fornecedorRepository.ListarAsync();
        var fornecedorDtos = fornecedores.Adapt<List<FornecedorResponse>>();
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, fornecedorDtos));
    }
}

public sealed class ObterFornecedorPorCNPJQueryHandler : IRequestHandler<ObterFornecedorPorCNPJQuery, Resposta>
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public ObterFornecedorPorCNPJQueryHandler(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public Task<Resposta> Handle(ObterFornecedorPorCNPJQuery request, CancellationToken cancellationToken)
    {
        var fornecedor = _fornecedorRepository.ObterPorCnpjAsync(request.CNPJ);
        var fornecedorResponse = fornecedor.Adapt<FornecedorResponse>();
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, fornecedorResponse));
    }
}