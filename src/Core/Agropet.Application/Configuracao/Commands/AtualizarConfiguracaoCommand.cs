using Agropet.Application.Common.Response;
using Agropet.Domain.Enums;
using MediatR;

namespace Agropet.Application.Configuracao.Commands;

public sealed record AtualizarConfiguracaoCommand(int Id, ENomeConfiguracao ENomeConfiguracao, string Valor) : IRequest<Resposta>;
