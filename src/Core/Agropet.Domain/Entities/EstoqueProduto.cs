namespace Agropet.Domain.Entities;

public class EstoqueProduto : BaseEntity
{
    public EstoqueProduto()
    {
    }

    public EstoqueProduto(int quantidadeProduto, Estoque estoque, Produto produto)
    {
        QuantidadeProduto = quantidadeProduto;
        Estoque = estoque;
        Produto = produto;
    }

    public int QuantidadeProduto { get; set; }

    public int IdEstoque { get; set; }
    public Estoque Estoque { get; set; } = null!;

    public int IdProduto { get; set; }
    public Produto Produto { get; set; } = null!;

}
