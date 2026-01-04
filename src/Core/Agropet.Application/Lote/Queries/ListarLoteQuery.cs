using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Lote.Queries;

public sealed record ListarLoteQuery : IRequest<Resposta>;