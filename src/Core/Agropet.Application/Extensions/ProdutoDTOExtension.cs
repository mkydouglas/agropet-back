using Agropet.Application.DTOs;
using Agropet.Domain.Entities;
using Agropet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agropet.Application.Extensions;

public static class ProdutoDTOExtension
{
    public static List<ProdutoDTO> MapearParaListaProdutoDTO(this List<InfoProduto> infoProduto)
    {
        List<ProdutoDTO> produtos = new List<ProdutoDTO>();

        foreach (var produto in infoProduto)
        {
            produtos.Add(new ProdutoDTO
            {
                Codigo = produto.Produto.Codigo,
                CodigoBarras = produto.Produto.CodigoBarras,
                Nome = produto.Produto.Nome,
                LoteDTO = new LoteDTO
                {
                    Numero = produto.Produto.Rastro?.NLote.ToString(),
                    Quantidade = double.Parse(produto.Produto.QuantidadeComercial),
                    DataFabricacao = produto.Produto.Rastro?.DFab,
                    DataValidade = produto.Produto.Rastro?.DVal,
                    UnidadeComercial = produto.Produto.UnidadeComercial,
                    PrecoUnitarioCompra = produto.Produto.ValorUnidadeComercial,
                    DataEntrada = DateTime.Now
                }
            });
        }

        return produtos;
    }

    public static List<ListarProdutoDTO> MapearParaListaProdutoDTO(this IEnumerable<Produto> produtos)
    {
        List<ListarProdutoDTO> produtosDTO = new List<ListarProdutoDTO>();

        foreach (var produto in produtos)
        {
            var prod = new ListarProdutoDTO();
            prod.Codigo = produto.Codigo;
            prod.CodigoBarras = produto.CodigoBarras;
            prod.Nome = produto.Nome;

            //if (produto.Lotes != null)
            //{
            //    foreach (var lote in produto.Lotes)
            //    {
            //        prod.LotesDTO.Add(new LoteDTO
            //        {
            //            Numero = lote.Numero,
            //            Quantidade = lote.Quantidade,
            //            DataFabricacao = lote.DataFabricacao,
            //            DataValidade = lote.DataValidade,
            //            UnidadeComercial = lote.UnidadeComercial,
            //            PrecoUnitarioCompra = lote.PrecoUnitarioCompra,
            //            DataEntrada = lote.DataEntrada
            //        });                    
            //    }
            //}

            produtosDTO.Add(prod);
        }

        return produtosDTO;
    }
}
