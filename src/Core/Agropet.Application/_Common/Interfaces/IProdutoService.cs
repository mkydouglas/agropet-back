using Agropet.Application.Common.DTOs;

namespace Agropet.Application.Common.Interfaces;

public interface IProdutoService : IServiceBase<Domain.Entities.Produto>
{
    //int Cadastrar(ProdutoDTO produtoDTO);
    Domain.Entities.Produto? ObterPorCodigoBarras(long codigoBarras);
    new List<ListarProdutoDTO> Listar();
}
