using Agropet.Application.DTOs;
using Agropet.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Produto.Commands;

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
