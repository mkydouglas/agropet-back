using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente Obter(string cpf);
    }
}
