using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        T Criar(T usuario);
        T Atualizar(T entity);
        int Deletar(int id);
        T Obter(int id);
        IEnumerable<T> Listar();
    }
}
