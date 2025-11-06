using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.DTOs;

public class LoteDTO
{
    public string? Numero { get; set; }
    public double Quantidade { get; set; }
    public string? UnidadeComercial { get; set; }
    public decimal PrecoUnitarioCompra { get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime? DataValidade { get; set; }
    public DateTime? DataEntrada { get; set; }

    public static explicit operator Lote(LoteDTO? dto)
    {
        return new Lote
        {
            Numero = dto?.Numero,
            Quantidade = dto?.Quantidade ?? 0,
            UnidadeComercial = dto?.UnidadeComercial,
            PrecoUnitarioCompra = dto?.PrecoUnitarioCompra ?? 0,
            DataFabricacao = dto?.DataFabricacao,
            DataValidade = dto?.DataValidade,
            DataEntrada = dto?.DataEntrada,
        };
    }
}
