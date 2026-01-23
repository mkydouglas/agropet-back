using Agropet.Application.Common.Response;
using Agropet.Application.FormaPagamento.Queries;
using Agropet.Application.FormaPagamento.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System.Net;

namespace Agropet.Application.FormaPagamento.Handlers;

public sealed class ListarFormaPagamentoHandler : IRequestHandler<ListarFormaPagamentoQuery, Resposta>
{
    private readonly IFormaPagamentoRepository _repository;

    public ListarFormaPagamentoHandler(IFormaPagamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Resposta> Handle(ListarFormaPagamentoQuery request, CancellationToken cancellationToken)
    {
        var formas = await _repository.ListarAsync();
        var response = formas.Adapt<List<FormaPagamentoResponse>>();
        return new Resposta((int)HttpStatusCode.OK, response);
    }
}
