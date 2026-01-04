namespace Agropet.Domain.Entities;

public class ItemCompra : BaseEntity
{
    public ItemCompra()
    {
        
    }

    public ItemCompra(int quantidade, decimal preco, Compra compra, Produto produto)
    {
        Quantidade = quantidade;
        Preco = preco;
        Compra = compra;
        Produto = produto;
    }

    public int Quantidade { get; private set; }
    public decimal Preco { get; private set; }

    public int IdCompra { get; set; }
    public Compra Compra { get; set; } = null!;
    public int IdProduto { get; set; }
    public Produto Produto { get; set; } = null!;

    public void Atualizar(int quantidade, decimal preco, Compra compra, Produto produto)
    {
        Quantidade = quantidade;
        Preco = preco;
        Produto = produto;
        Quantidade = quantidade;
    }
}
