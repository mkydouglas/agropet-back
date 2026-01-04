using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;

namespace Agropet.Infrastructure.Repositories;

public class VendaRepository : BaseRepository<Venda>, IVendaRepository
{
    public VendaRepository(AppDbContext context) : base(context)
    {
    }
}
