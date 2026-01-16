using Agropet.Domain.Entities;
using Agropet.Domain.Enums;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Agropet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agropet.Persistence.Repositories;

public class ConfiguracaoRepository : BaseRepository<Configuracao>, IConfiguracaoRepository
{
    private readonly AppDbContext context;

    public ConfiguracaoRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<Configuracao> ObterPorNome(ENomeConfiguracao eNomeConfiguracao)
    {
        return await context.Configuracao.FirstAsync(c => c.Nome == eNomeConfiguracao);
    }
}
