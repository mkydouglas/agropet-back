using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Auth.Commands;

public sealed record AuthCommand(string CPF, string Senha) : IRequest<Resposta>;
