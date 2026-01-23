namespace Agropet.Application.Common.Interfaces;

public interface IProdutoService : IServiceBase<Domain.Entities.Produto>
{
    Domain.Entities.Produto? ObterPorCodigoBarras(long codigoBarras);
}
