using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services;

public class ProdutoVendaService : ServiceBase<ProdutoVenda>, IProdutoVendaService
{
    public ProdutoVendaService(IProdutoVendaRepository produtoVendaRepository) : base(produtoVendaRepository)
    {
    }
}
