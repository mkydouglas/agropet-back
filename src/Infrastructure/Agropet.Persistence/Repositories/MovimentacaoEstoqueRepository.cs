using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;

namespace Agropet.Infrastructure.Repositories;

public class MovimentacaoEstoqueRepository : BaseRepository<MovimentacaoEstoque>, IMovimentacaoEstoqueRepository
{
    public MovimentacaoEstoqueRepository(AppDbContext context) : base(context)
    {
    }
}
