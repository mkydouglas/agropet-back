using Agropet.Application.Response;
using MediatR;

namespace Agropet.Application.UseCases.Lote.Queries;

public sealed record ListarLoteQuery : IRequest<Resposta>;