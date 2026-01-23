using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.FormaPagamento.Queries;

public sealed record ListarFormaPagamentoQuery : IRequest<Resposta>;