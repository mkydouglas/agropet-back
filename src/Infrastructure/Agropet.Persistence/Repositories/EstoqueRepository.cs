using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Agropet.Infrastructure.Repositories;

namespace Agropet.Persistence.Repositories;

public class EstoqueRepository : BaseRepository<Estoque>, IEstoqueRepository
{
    public EstoqueRepository(AppDbContext context) : base(context)
    {
    }
}
