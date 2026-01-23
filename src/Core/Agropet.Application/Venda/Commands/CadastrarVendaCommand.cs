using Agropet.Application.Common.Response;
using Agropet.Application.Venda.Inputs;
using MediatR;

namespace Agropet.Application.Venda.Commands;

public sealed record CadastrarVendaCommand : CommandQueryBase, IRequest<Resposta>
{
    public required List<ProdutosVendidosInput> ProdutosVendidosInput { get; set; }
    public int QtdeTotalItens { get; set; }
    public decimal ValorTotal { get; set; }
    public decimal ValorPago { get; set; }
    public decimal Desconto { get; set; }
    public required List<FormaPagamentoInput> FormaPagamentoInput { get; set; }
}
