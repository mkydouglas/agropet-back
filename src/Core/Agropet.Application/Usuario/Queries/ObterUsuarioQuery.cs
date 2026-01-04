using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Usuario.Queries;

public sealed record ObterUsuarioQuery(int id) : IRequest<Resposta>;
