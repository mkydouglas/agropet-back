using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services;

public class ProdutoService : ServiceBase<Domain.Entities.Produto>//, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    //public int Cadastrar(ProdutoDTO produtoDTO)
    //{
    //    var produto = _produtoRepository.ObterPorCodigoBarras(produtoDTO.CodigoBarras);
    //    if(produto == null)
    //    {
    //        //produto = (Produto)produtoDTO;
    //        produto.CalcularPrecoVenda(produtoDTO.LoteDTO!.PrecoUnitarioCompra, 0.4);
    //        produto = Criar(produto);
    //    }

    //    return produto.Id;
    //}

    //public Produto? ObterPorCodigoBarras(long codigoBarras)
    //{
    //    return _produtoRepository.ObterPorCodigoBarras(codigoBarras);
    //}

    //public new List<ListarProdutoDTO> Listar()
    //{
    //    var produtos = _produtoRepository.Listar();
    //    return produtos.MapearParaListaProdutoDTO();
    //}
}
