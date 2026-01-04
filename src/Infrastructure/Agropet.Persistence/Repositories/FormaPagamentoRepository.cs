using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;

namespace Agropet.Infrastructure.Repositories;

public class FormaPagamentoRepository : BaseRepository<FormaPagamento>, IFormaPagamentoRepository
{
    public FormaPagamentoRepository(AppDbContext context) : base(context)
    {
    }
}
