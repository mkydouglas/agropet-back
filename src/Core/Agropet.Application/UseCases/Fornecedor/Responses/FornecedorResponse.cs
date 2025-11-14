using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Fornecedor.Responses;

public sealed record FornecedorResponse
{
    public int Id { get; set; }
    public string? CNPJ { get; set; }
    public string? RazaoSocial { get; set; }
    public string? NomeFantasia { get; set; }
    public string? Telefone { get; set; }
}
