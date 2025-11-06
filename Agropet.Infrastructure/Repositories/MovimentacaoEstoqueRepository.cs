using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Infrastructure.Repositories;

public class MovimentacaoEstoqueRepository : RepositoryBase<MovimentacaoEstoque>, IMovimentacaoEstoqueRepository
{
    public MovimentacaoEstoqueRepository(AppDbContext context) : base(context)
    {
    }
}
