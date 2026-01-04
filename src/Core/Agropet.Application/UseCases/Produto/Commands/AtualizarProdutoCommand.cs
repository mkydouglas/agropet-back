using Agropet.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Produto.Commands;

public sealed record AtualizarProdutoCommand : IRequest<Resposta>
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Codigo { get; set; }
    public required string CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoVenda { get; set; }
    public int IdUsuario { get; set; }
}
