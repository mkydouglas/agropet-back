using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Agropet.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Persistence.Repositories;

public class ItemCompraRepository : BaseRepository<ItemCompra>, IItemCompraRepository
{
    public ItemCompraRepository(AppDbContext context) : base(context)
    {
    }
}
