using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Agropet.Infrastructure.Repositories;

namespace Agropet.Persistence.Repositories;

public class ItemCompraRepository : BaseRepository<ItemCompra>, IItemCompraRepository
{
    public ItemCompraRepository(AppDbContext context) : base(context)
    {
    }
}
