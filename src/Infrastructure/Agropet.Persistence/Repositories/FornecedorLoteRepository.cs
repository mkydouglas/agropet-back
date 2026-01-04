using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Agropet.Infrastructure.Repositories;

namespace Agropet.Persistence.Repositories;
public class FornecedorLoteRepository : BaseRepository<FornecedorProduto>, IFornecedorLoteRepository
{
    public FornecedorLoteRepository(AppDbContext context) : base(context)
    {
    }
}
