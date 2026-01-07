namespace Agropet.Application._Common.DTOs;

public sealed record FornecedorDTO
{
    public required string CNPJ { get; init; }
    public string? RazaoSocial { get; init; }
    public string? NomeFantasia { get; init; }
    public string? Telefone { get; init; }
}
