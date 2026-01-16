using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Configuracao.Queries;

public sealed record ListarConfiguracaoQuery : IRequest<Resposta>;
