using Agropet.Application.DTOs;
using Agropet.Domain.Models;

namespace Agropet.Application.Extensions;

public static class FornecedorDTOExtension
{
    public static FornecedorDTO MapearParaFornecedorDTO(this Emitente emitente)
    {
        return new FornecedorDTO
        {
            CNPJ = emitente.CNPJ,
            RazaoSocial = emitente.RazaoSocial,
            NomeFantasia = emitente.NomeFantasia,
            Telefone = emitente.EnderEmit.Fone
        };
    }
}
