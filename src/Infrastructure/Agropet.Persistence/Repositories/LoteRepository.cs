using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Infrastructure.Repositories;

public class LoteRepository : BaseRepository<Lote>, ILoteRepository
{
    public LoteRepository(AppDbContext context) : base(context)
    {
    }
}
