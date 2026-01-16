using Agropet.Domain.Entities;
using Agropet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agropet.Domain.Interfaces;

public interface IConfiguracaoRepository : IBaseRepository<Configuracao>
{
    Task<Configuracao> ObterPorNome(ENomeConfiguracao eNomeConfiguracao);
}
