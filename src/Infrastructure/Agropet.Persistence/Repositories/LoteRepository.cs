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

    public async Task<List<Lote>> ObterLotesPorFifo(int idProduto)
    {
        return await context.Lote
            .Where(l => l.IdProduto == idProduto && l.Quantidade > 0)
            .OrderBy(l => l.DataInclusao)
            .ToListAsync();
    }

    public async Task<List<Lote>> ObterLotesPorFifo(IEnumerable<int> idsProduto)
    {
        return await context.Lote
            .Where(l =>
                idsProduto.Contains(l.IdProduto) &&
                l.Quantidade > 0
            )
            .OrderBy(l => l.IdProduto)      // importante para agrupar
            .ThenBy(l => l.DataInclusao)    // FIFO dentro do produto
            .ToListAsync();
    }

}
