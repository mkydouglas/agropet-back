namespace Agropet.Domain.Entities;

public class Lote : BaseEntity
{
    public string Numero { get; private set; } = null!;
    public int Quantidade { get; private set; }
    public DateTime DataFabricacao { get; private set; }
    public DateTime DataValidade { get; private set; }

    public void Atualizar(
        string numero,
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

    #region Relacionamento

    public int IdProduto { get; private set; }
    public Produto? Produto { get; private set; }

    #endregion
}
