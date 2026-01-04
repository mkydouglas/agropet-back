using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agropet.Infrastructure.Repositories;

public class LoteRepository : BaseRepository<Lote>, ILoteRepository
{
    private readonly AppDbContext context;

    public LoteRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<Dictionary<string, Lote>> ListarPorNumeroAsync(List<string> numeroLotes)
    {
        return await context.Lote.Where(l => numeroLotes.Contains(EF.Functions.Collate(l.Numero, "SQL_Latin1_General_CP1_CI_AS"))).ToDictionaryAsync(l => l.Numero);
    }

    public void CriarRange(List<Lote> lotes)
    {
        context.Lote.AddRange(lotes);
    }
}
