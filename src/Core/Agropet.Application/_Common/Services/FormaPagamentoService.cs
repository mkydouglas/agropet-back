using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services;

public class FormaPagamentoService : ServiceBase<FormaPagamento>, IFormaPagamentoService
{
    public FormaPagamentoService(IFormaPagamentoRepository formaPagamentoRepository) : base(formaPagamentoRepository)
    {
    }
}
