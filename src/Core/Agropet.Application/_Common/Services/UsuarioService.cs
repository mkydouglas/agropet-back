using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services
{
    public class UsuarioService : ServiceBase<Domain.Entities.Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Domain.Entities.Usuario Obter(string cpf)
        {
            return _usuarioRepository.Obter(cpf);
        }
    }
}
