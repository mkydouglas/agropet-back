using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces;

public interface IFornecedorRepository : IBaseRepository<Fornecedor>
{
    Task<Fornecedor?> ObterPorCnpjAsync(string cnpj);
}
