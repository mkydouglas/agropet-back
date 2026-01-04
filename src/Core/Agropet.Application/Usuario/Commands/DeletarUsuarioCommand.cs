using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Usuario.Commands;

public sealed record DeletarUsuarioCommand(int id) : IRequest<Resposta>;