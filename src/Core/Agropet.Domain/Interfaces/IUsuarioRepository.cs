using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Obter(string cpf);
    }
}
