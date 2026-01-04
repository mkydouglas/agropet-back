using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Usuario.Queries;

public sealed record ListarUsuarioQuery : IRequest<Resposta>;