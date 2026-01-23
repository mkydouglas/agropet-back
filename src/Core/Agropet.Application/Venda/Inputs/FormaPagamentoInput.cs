namespace Agropet.Application.Venda.Inputs;

public sealed record FormaPagamentoInput
{
    public int IdFormaPagamento { get; set; }
    public decimal ValorPago { get; set; }
    public int QuantidadeParcelas { get; set; }
}
