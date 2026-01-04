using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Usuario.Commands;

public sealed record CadastrarUsuarioCommand(string Nome, string CPF, string Senha) : IRequest<Resposta>;
