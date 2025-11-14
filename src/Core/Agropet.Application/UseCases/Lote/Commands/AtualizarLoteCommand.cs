using Agropet.Application.Response;
using MediatR;

namespace Agropet.Application.UseCases.Lote.Commands;

public sealed record AtualizarLoteCommand : IRequest<Resposta>
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