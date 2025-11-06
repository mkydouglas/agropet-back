using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _context.SaveChanges();
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
            _context.SaveChanges();
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
                return _context.SaveChanges();
            }

            return 0;
        }

        public IEnumerable<T> Listar()
        {
            return _context.Set<T>().ToList();
        }

        public T Obter(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
