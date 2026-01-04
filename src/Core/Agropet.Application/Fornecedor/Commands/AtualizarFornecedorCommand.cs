using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Fornecedor.Commands;

public sealed record AtualizarFornecedorCommand : IRequest<Resposta>
{
    public int Id { get; set; }
    public string? CNPJ { get; set; }
    public string? RazaoSocial { get; set; }
    public string? NomeFantasia { get; set; }
    public string? Telefone { get; set; }
}