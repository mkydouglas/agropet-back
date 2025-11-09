using Agropet.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Auth.Commands;

public sealed record AuthCommand(string CPF, string Senha) : IRequest<Resposta>;
