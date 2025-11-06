using Agropet.Domain.Entities;

namespace Agropet.Application.DTOs;

public class FornecedorDTO
{
    public string? CNPJ { get; set; }
    public string? RazaoSocial { get; set; }
    public string? NomeFantasia { get; set; }
    public string? Telefone { get; set; }

    public static explicit operator Fornecedor(FornecedorDTO dto)
    {
        return new Fornecedor()
        {
            CNPJ = dto.CNPJ,
            NomeFantasia = dto.NomeFantasia,
            RazaoSocial = dto.RazaoSocial,
            Telefone = dto.Telefone
        };
    }
}
