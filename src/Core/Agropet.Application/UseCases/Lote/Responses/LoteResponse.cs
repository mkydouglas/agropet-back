using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Lote.Responses;

public sealed record LoteResponse
{
    public int Id { get; set; }
    public string? Numero { get; set; }
    public double Quantidade { get; set; }
    public string? UnidadeComercial { get; set; }
    public decimal PrecoUnitarioCompra { get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime? DataValidade { get; set; }
    public DateTime? DataEntrada { get; set; }
}
