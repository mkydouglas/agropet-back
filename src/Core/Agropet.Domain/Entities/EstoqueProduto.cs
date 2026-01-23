using System.ComponentModel.DataAnnotations;

namespace Agropet.Domain.Entities;

public class EstoqueProduto : BaseEntity
{
    public int QuantidadeProduto { get; private set; }

    public int IdEstoque { get; private set; }
    public Estoque Estoque { get; private set; } = null!;

    public int IdProduto { get; private set; }
    public Produto Produto { get; private set; } = null!;

    [Timestamp]
    public byte[] RowVersion { get; private set; } = null!;

    private EstoqueProduto() { }

    public static EstoqueProduto Criar(
    int produtoId,
    int estoqueId,
    int quantidadeInicial)
    {
        if (quantidadeInicial < 0)
            throw new Exception("Quantidade inválida");
        //throw new DomainException("Quantidade inválida");

        return new EstoqueProduto
        {
            IdProduto = produtoId,
            IdEstoque = estoqueId,
            QuantidadeProduto = quantidadeInicial
        };
    }

    public void Entrar(int quantidade)
    {
        QuantidadeProduto += quantidade;
    }

    public void Sair(int quantidade)
    {
        if (QuantidadeProduto < quantidade)
            throw new Exception("Estoque insuficiente");
        //throw new DomainException("Estoque insuficiente");

        QuantidadeProduto -= quantidade;
    }
}

