namespace Agropet.Application.Common.Interfaces
{
    public interface IUsuarioService : IServiceBase<Domain.Entities.Usuario>
    {
        Domain.Entities.Usuario Obter(string cpf);
    }
}
