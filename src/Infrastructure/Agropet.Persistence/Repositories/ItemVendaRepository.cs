using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;

namespace Agropet.Infrastructure.Repositories;

public class ItemVendaRepository : BaseRepository<ItemVenda>, IItemVendaRepository
{
    public ItemVendaRepository(AppDbContext context) : base(context)
    {
    }
}
