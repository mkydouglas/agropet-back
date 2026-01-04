using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services;

public class VendaFormaPagamentoService : ServiceBase<VendaFormaPagamento>, IVendaFormaPagamentoService
{
    public VendaFormaPagamentoService(IVendaFormaPagamentoRepository vendaFormaPagamentoRepository) : base(vendaFormaPagamentoRepository)
    {
    }
}
