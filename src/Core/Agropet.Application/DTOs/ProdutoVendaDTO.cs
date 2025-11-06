using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.DTOs;

public class ProdutoVendaDTO
{
    public int IdProduto { get; set; }
    public decimal PrecoProduto { get; set; }
    public double Quantidade { get; set; }
    public decimal ValorPago { get; set; }

    public static explicit operator ProdutoVenda(ProdutoVendaDTO dto)
    {
        return new ProdutoVenda
        {
            IdProduto = dto.IdProduto,
            PrecoProduto = dto.PrecoProduto,
            Quantidade = dto.Quantidade,
            ValorPago = dto.ValorPago,
        };
    }
}
