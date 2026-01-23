namespace Agropet.Application.Venda.Inputs;

public sealed record ProcessarVendaInput
(
    int IdUsuario,
    int IdEstoque,
    List<ProdutosVendidosInput> ProdutosVendidosInput,
    int QtdeTotalItens,
    decimal ValorTotal,
    decimal ValorPago,
    decimal Desconto,
    List<FormaPagamentoInput> FormaPagamentoInput
);
