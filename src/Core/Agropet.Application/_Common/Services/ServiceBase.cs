using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repositoryBase;

        public ServiceBase(IBaseRepository<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public T Atualizar(T entity)
        {
            return _repositoryBase.Atualizar(entity);
        }

        public T Criar(T entity)
        {
            return null;// _repositoryBase.Criar(entity);
        }

        public int Deletar(int id)
        {
            return _repositoryBase.Deletar(id);
        }

        public IEnumerable<T> Listar()
        {
            return _repositoryBase.Listar();
        }

        public T Obter(int id)
        {
            return null;// _repositoryBase.ObterAsync(id);
        }
    }
}
