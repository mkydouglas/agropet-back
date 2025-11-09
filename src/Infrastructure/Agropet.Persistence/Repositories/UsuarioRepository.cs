using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;

namespace Agropet.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Usuario Obter(string cpf)
        {
            return _context.Usuario.Where(u => u.CPF == cpf).First();
        }
    }
}
