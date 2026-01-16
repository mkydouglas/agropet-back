using Agropet.Application.Common.Response;
using Agropet.Application.Lote.Queries;
using Agropet.Application.Lote.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System.Net;

namespace Agropet.Application.Lote.Handlers;

public sealed class ListarLoteQueryHandler : IRequestHandler<ListarLoteQuery, Resposta>
{
    private readonly ILoteRepository _loteRepository;

    public ListarLoteQueryHandler(ILoteRepository loteRepository)
    {
        _loteRepository = loteRepository;
    }

    public Task<Resposta> Handle(ListarLoteQuery request, CancellationToken cancellationToken)
    {
        var lotes = _loteRepository.ListarAsync();
        var loteDtos = lotes.Adapt<List<LoteResponse>>();
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, loteDtos));
    }
}