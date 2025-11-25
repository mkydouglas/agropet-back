namespace Agropet.Domain.Entities;

public class Lote : BaseEntity
{
    //TODO: a quem pertence unidadeComercial e precoUnitarioCompra?
    public string Numero { get; private set; } = null!;
    public double Quantidade { get; private set; }
    public string? UnidadeComercial { get; private set; }
    public decimal PrecoUnitarioCompra { get; private set; }
    public DateTime DataFabricacao { get; private set; }
    public DateTime DataValidade { get; private set; }

    public void Atualizar(
        string numero,
        double quantidade,
        string? unidadeComercial,
        decimal precoUnitarioCompra,
        DateTime dataFabricacao,
        DateTime dataValidade)
    {
        Numero = numero;
        Quantidade = quantidade;
        UnidadeComercial = unidadeComercial;
        PrecoUnitarioCompra = precoUnitarioCompra;
        DataFabricacao = dataFabricacao;
        DataValidade = dataValidade;
    }

    public void AtualizarQuantidade(double quantidade) => Quantidade += quantidade;
    public void ReferenciarProduto(Produto produto) => Produto = produto;

    #region Relacionamento

    public int IdProduto { get; private set; }
    public Produto? Produto { get; private set; }
    public ICollection<FornecedorLote>? FornecedorLote { get; set; }
    public ICollection<EstoqueLote>? EstoqueLote { get; set; }
    //public ICollection<MovimentacaoEstoque>? MovimentacaoEstoques { get; set; }

    #endregion
}
