using System.Text.Json.Serialization;

namespace Agropet.Application.Compra.Inputs;

public sealed record ItemCompraInput
{
    [JsonPropertyName("produto")]
    public required ProdutoInput ProdutoInput { get; init; }
    public int Quantidade { get; init; }
    public decimal PrecoUnitario { get; init; }
    [JsonPropertyName("lote")]
    public LoteInput? LoteInput { get; init; }
}
