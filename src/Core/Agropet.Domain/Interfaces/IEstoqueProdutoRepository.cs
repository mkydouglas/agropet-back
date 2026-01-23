using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces;

public interface IEstoqueProdutoRepository : IBaseRepository<EstoqueProduto>
{
    Task<IEnumerable<EstoqueProduto>> ListarAsync(int idProduto, int idEstoque);
    Task<IEnumerable<EstoqueProduto>> ListarAsync(IEnumerable<int> idProdutos, int idEstoque);
}
