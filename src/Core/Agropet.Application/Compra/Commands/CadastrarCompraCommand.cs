using Agropet.Application.Common.Response;
using Agropet.Application.Compra.Inputs;
using MediatR;
using System.Text.Json.Serialization;

namespace Agropet.Application.Compra.Commands;

public sealed record CadastrarCompraCommand : CommandQueryBase, IRequest<Resposta>
{
    public string? NumeroNotaFiscal { get; set; }
    [JsonPropertyName("fornecedor")]
    public required FornecedorInput FornecedorInput { get; set; }
    public required List<ItemCompraInput> ItensComprados { get; set; }
}