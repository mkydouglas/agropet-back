using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Agropet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Agropet.Persistence.Repositories;

public class EstoqueProdutoRepository : BaseRepository<EstoqueProduto>, IEstoqueProdutoRepository
{
    private readonly AppDbContext context;

    public EstoqueProdutoRepository(AppDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<EstoqueProduto>> ListarAsync(int idProduto, int idEstoque)
    {
        return await context.EstoqueProduto.Where(ep => ep.IdProduto == idProduto && ep.IdEstoque == idEstoque).ToListAsync();
    }

    public async Task<IEnumerable<EstoqueProduto>> ListarAsync(IEnumerable<int> idProdutos, int idEstoque)
    {
        return await context.EstoqueProduto.Where(ep => idProdutos.Contains(ep.IdProduto) && ep.IdEstoque == idEstoque).ToListAsync();
    }
}
