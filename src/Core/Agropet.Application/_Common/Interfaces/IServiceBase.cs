namespace Agropet.Application.Common.Interfaces
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
