namespace Agropet.Application.Compra.Inputs;

public sealed record FornecedorInput
{
    public required string CNPJ { get; init; }
    public string? RazaoSocial { get; init; }
    public string? NomeFantasia { get; init; }
    public string? Telefone { get; init; }
}
