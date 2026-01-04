using Agropet.Domain.Entities;

namespace Agropet.Application.Common.DTOs;

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
