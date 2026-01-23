namespace Agropet.Domain.Entities;

public class Lote : BaseEntity
{
    public string? Numero { get; private set; }
    public int Quantidade { get; private set; }
    public DateTime DataFabricacao { get; private set; }
    public DateTime DataValidade { get; private set; }

    public void Atualizar(
        string? numero,
        int quantidade,
        string? unidadeComercial,
        decimal precoUnitarioCompra,
        DateTime dataFabricacao,
        DateTime dataValidade)
    {
        Numero = numero;
        Quantidade = quantidade;
        DataFabricacao = dataFabricacao;
        DataValidade = dataValidade;
    }

    public void AtualizarQuantidade(int quantidade) => Quantidade += quantidade;
    public void ReferenciarProduto(Produto produto) => Produto = produto;

    public void Sair(int quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("Quantidade inválida");
        //throw new DomainException("Quantidade inválida");

        if (quantidade > Quantidade)
            throw new Exception("Quantidade insuficiente no lote");
        //throw new DomainException("Quantidade insuficiente no lote");

        Quantidade -= quantidade;
    }

    #region Relacionamento

    public int IdProduto { get; private set; }
    public Produto Produto { get; private set; } = null!;
    public ICollection<MovimentacaoEstoque> MovimentacaoEstoques { get; set; } = [];

    #endregion
}
