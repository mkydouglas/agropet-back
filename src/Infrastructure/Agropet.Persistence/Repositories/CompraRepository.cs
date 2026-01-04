using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Agropet.Infrastructure.Repositories;

namespace Agropet.Persistence.Repositories;

public class CompraRepository : BaseRepository<Compra>, ICompraRepository
{
    public CompraRepository(AppDbContext context) : base(context)
    {
    }
}
