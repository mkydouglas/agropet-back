using Agropet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agropet.Application.Configuracao.Responses;

public sealed record ListarConfiguracaoResponse(int Id, ENomeConfiguracao ENomeConfiguracao, string Nome, string Valor);
