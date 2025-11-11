using Agropet.Application.DTOs;
using Agropet.Application.Extensions;
using Agropet.Application.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Services;

public class ProdutoService : ServiceBase<Produto>, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public int Cadastrar(ProdutoDTO produtoDTO)
    {
        var produto = _produtoRepository.ObterPorCodigoBarras(produtoDTO.CodigoBarras);
        if(produto == null)
        {
            //produto = (Produto)produtoDTO;
            produto.CalcularPrecoVenda(produtoDTO.LoteDTO!.PrecoUnitarioCompra, 0.4);
            produto = Criar(produto);
        }

        return produto.Id;
    }

    public Produto? ObterPorCodigoBarras(long codigoBarras)
    {
        return _produtoRepository.ObterPorCodigoBarras(codigoBarras);
    }

    public new List<ListarProdutoDTO> Listar()
    {
        var produtos = _produtoRepository.Listar();
        return produtos.MapearParaListaProdutoDTO();
    }
}
