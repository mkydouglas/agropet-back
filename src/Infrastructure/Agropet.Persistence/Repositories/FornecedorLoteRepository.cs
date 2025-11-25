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
public class FornecedorLoteRepository : BaseRepository<FornecedorProduto>, IFornecedorLoteRepository
{
    public FornecedorLoteRepository(AppDbContext context) : base(context)
    {
    }
}
