using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces;
public interface IProdutoRepository : IBaseRepository<Produto>
{
    Task<List<Produto>> ListarPorCodigoBarrasAsync(List<long> codigosDeBarra);
    Task<Produto?> ObterPorCodigoBarrasAsync(long codigoBarras);
}
