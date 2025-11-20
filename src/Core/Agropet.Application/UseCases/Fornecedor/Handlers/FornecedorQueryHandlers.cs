using Agropet.Application.DTOs;
using Agropet.Application.Response;
using Agropet.Application.UseCases.Fornecedor.Queries;
using Agropet.Application.UseCases.Fornecedor.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Fornecedor.Handlers;

public sealed class ListarFornecedorQueryHandler : IRequestHandler<ListarFornecedorQuery, Resposta>
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public ListarFornecedorQueryHandler(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public Task<Resposta> Handle(ListarFornecedorQuery request, CancellationToken cancellationToken)
    {
        var fornecedores = _fornecedorRepository.Listar();
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
        var fornecedor = _fornecedorRepository.ObterPorCnpj(request.CNPJ);
        var fornecedorResponse = fornecedor.Adapt<FornecedorResponse>();
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, fornecedorResponse));
    }
}