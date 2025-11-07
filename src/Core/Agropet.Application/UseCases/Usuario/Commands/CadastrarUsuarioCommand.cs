using Agropet.Application.Response;
using MediatR;

namespace Agropet.Application.UseCases.Usuario.Commands;

public sealed record CadastrarUsuarioCommand(string Nome, string CPF, string Senha) : IRequest<Resposta>;
