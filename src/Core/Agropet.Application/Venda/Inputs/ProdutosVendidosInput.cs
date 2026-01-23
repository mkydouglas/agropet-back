namespace Agropet.Application.Venda.Inputs;

public sealed record ProdutosVendidosInput
{
    public int IdProduto { get; set; }
    public decimal PrecoProduto { get; set; }
    public double Quantidade { get; set; }
    public decimal ValorPago { get; set; }
    public decimal Desconto { get; set; }
}
