using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services;

public class ProdutoVendaService : ServiceBase<ItemVenda>, IProdutoVendaService
{
    public ProdutoVendaService(IItemVendaRepository produtoVendaRepository) : base(produtoVendaRepository)
    {
    }
}
