using Agropet.Application.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Services;

public class VendaFormaPagamentoService : ServiceBase<VendaFormaPagamento>, IVendaFormaPagamentoService
{
    public VendaFormaPagamentoService(IVendaFormaPagamentoRepository vendaFormaPagamentoRepository) : base(vendaFormaPagamentoRepository)
    {
    }
}
