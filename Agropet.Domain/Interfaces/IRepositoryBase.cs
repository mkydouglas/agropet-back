using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T Criar(T entity);
        T Atualizar(T entity);
        int Deletar(int id);
        T Obter(int id);
        IEnumerable<T> Listar();
        Task<T> CriarTeste(T entity);
    }
}
