using Agropet.Application.DTOs;
using Agropet.Application.Response;
using Agropet.Application.UseCases.Lote.Queries;
using Agropet.Application.UseCases.Lote.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Lote.Handlers;

public sealed class ListarLoteQueryHandler : IRequestHandler<ListarLoteQuery, Resposta>
{
    private readonly ILoteRepository _loteRepository;

    public ListarLoteQueryHandler(ILoteRepository loteRepository)
    {
        _loteRepository = loteRepository;
    }

    public Task<Resposta> Handle(ListarLoteQuery request, CancellationToken cancellationToken)
    {
        var lotes = _loteRepository.Listar();
        var loteDtos = lotes.Adapt<List<LoteResponse>>();
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, loteDtos));
    }
}