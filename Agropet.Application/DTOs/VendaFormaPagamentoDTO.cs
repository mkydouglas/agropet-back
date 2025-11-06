using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.DTOs;

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
