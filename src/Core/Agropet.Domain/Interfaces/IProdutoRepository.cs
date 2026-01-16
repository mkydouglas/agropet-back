using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces;
public interface IProdutoRepository : IBaseRepository<Produto>
{
    Task<List<Produto>> ListarPorCodigoBarrasAsync(List<string> codigosDeBarra);
    Task<Produto?> ObterPorCodigoBarrasAsync(string codigoBarras);
    new Task<List<Produto>> ListarAsync();
}
