using Agropet.Domain.Entities;

namespace Agropet.Application.Common.DTOs;

public class VendaFormaPagamentoDTO
{
    public int IdFormaPagamento { get; set; }
    public decimal ValorPago { get; set; }

    public static explicit operator VendaFormaPagamento(VendaFormaPagamentoDTO dto)
    {
        return new VendaFormaPagamento
        {
            IdFormaPagamento = dto.IdFormaPagamento,
            ValorPago = dto.ValorPago
        };
    }
}
