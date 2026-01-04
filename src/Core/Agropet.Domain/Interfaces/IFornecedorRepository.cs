using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces;

public interface IFornecedorRepository : IBaseRepository<Fornecedor>
{
    Fornecedor? ObterPorCnpj(string cnpj);
}
