using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Usuario.Commands;

public sealed record AtualizarUsuarioCommand(int Id, string Nome, string CPF) : IRequest<Resposta>;
