using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;

namespace Agropet.Infrastructure.Repositories;

public class VendaFormaPagamentoRepository : BaseRepository<VendaFormaPagamento>, IVendaFormaPagamentoRepository
{
    public VendaFormaPagamentoRepository(AppDbContext context) : base(context)
    {
    }
}
