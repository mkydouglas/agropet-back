using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Produto.Commands;

public sealed record AtualizarProdutoCommand : IRequest<Resposta>
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Codigo { get; set; }
    public required string CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoVenda { get; set; }
    public string UnidadeComercial { get; set; }
}
