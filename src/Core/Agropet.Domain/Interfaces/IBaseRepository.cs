using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Criar(T entity);
        T Atualizar(T entity);
        int Deletar(int id);
        Task<T?> ObterAsync(int id);
        IEnumerable<T> Listar();
        Task<T> CriarTeste(T entity);
        Task<IDictionary<int, T>> ListarPorIdsAsync(IEnumerable<int> ids);
    }
}
