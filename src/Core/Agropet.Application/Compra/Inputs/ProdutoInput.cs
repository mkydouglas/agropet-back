namespace Agropet.Application.Compra.Inputs;

public sealed record ProdutoInput
{
    public int? Id { get; init; }
    public required string Nome { get; init; }
    public required string CodigoBarras { get; init; }
    public string? Codigo { get; init; }
    public string? UnidadeComercial { get; init; }
    public double? Margem { get; init; }
}
