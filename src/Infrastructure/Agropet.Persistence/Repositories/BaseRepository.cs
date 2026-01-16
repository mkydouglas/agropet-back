using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agropet.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public T Atualizar(T entity)
        {
            var existe = _context.Set<T>().Find(entity.Id);
            if (existe != null)
            {
                _context.Entry(existe).State = EntityState.Detached;

                _context.Set<T>().Update(entity);
                return entity;
            }
            else
            {
                throw new Exception();
            }
        }

        public T Criar(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> CriarTeste(T entity)
        {
            bool canConnect = _context.Database.CanConnect();
            Console.WriteLine($"Conexão com banco: {canConnect}");

            _context.Set<T>().Add(entity);
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await _context.SaveChangesAsync(cts.Token);

            //_context.SaveChanges();
            return entity;
        }

        public int Deletar(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return 1;
            }

            return 0;
        }

        public async Task<IEnumerable<T>> ListarAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> ObterAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListarPorIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Set<T>().Where(e => ids.Contains(e.Id)).ToListAsync();
        }
    }
}
