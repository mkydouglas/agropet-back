using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.DTOs;

public class VendaDTO
{
    public List<ProdutoVendaDTO>? ProdutoVendaDTOs { get; set; }
    public int QtdeTotalItens { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal ValorPago { get; set; }
    public List<VendaFormaPagamentoDTO>? VendaFormaPagamentoDTOs { get; set; }

    public static explicit operator Venda(VendaDTO vendaDTO)
    {
        return new Venda()
        {
            QtdeTotalItens = vendaDTO.QtdeTotalItens,
            ValorTotal = vendaDTO.ValorTotal,
            ValorPago = vendaDTO.ValorPago
        };
    }
}
