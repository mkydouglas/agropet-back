using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces;
public interface IProdutoRepository : IRepositoryBase<Produto>
{
    Produto? ObterPorCodigoBarras(long codigoBarras);
}
