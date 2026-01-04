using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;

namespace Agropet.Infrastructure.Repositories;

public class ProdutoVendaRepository : BaseRepository<ProdutoVenda>, IProdutoVendaRepository
{
    public ProdutoVendaRepository(AppDbContext context) : base(context)
    {
    }
}
