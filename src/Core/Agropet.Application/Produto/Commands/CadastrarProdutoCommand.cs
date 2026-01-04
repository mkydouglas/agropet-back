using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Produto.Commands;

public sealed record CadastrarProdutoCommand : IRequest<Resposta>
{
    public string Nome { get; set; } = null!;
    public int Codigo { get; set; }
    public long CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoVenda { get; set; }
    public int IdUsuario { get; set; }
    public int? IdLote { get; set; }
}
