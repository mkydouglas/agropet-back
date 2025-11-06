using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces;
public interface IProdutoRepository : IBaseRepository<Produto>
{
    Produto? ObterPorCodigoBarras(long codigoBarras);
}
