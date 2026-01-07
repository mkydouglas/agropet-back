namespace Agropet.Application.Compra.Inputs;

public sealed record LoteInput
{
    public int? Id { get; init; }
    public string? Numero { get; init; }
    public DateTime? DataFabricacao { get; init; }
    public DateTime? DataValidade { get; init; }
}
