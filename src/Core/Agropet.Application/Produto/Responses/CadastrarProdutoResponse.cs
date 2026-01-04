namespace Agropet.Application.Produto.Responses;

public sealed record CadastrarProdutoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public int Codigo { get; set; }
    public long CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoVenda { get; set; }
}
