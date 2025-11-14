namespace Agropet.Domain.Entities;

public class Lote : BaseEntity
{
    public string? Numero { get; private set; }
    public double Quantidade { get; private set; }
    public string? UnidadeComercial { get; private set; }
    public decimal PrecoUnitarioCompra { get; private set; }
    public DateTime? DataFabricacao { get; private set; }
    public DateTime? DataValidade { get; private set; }
    public DateTime? DataEntrada { get; private set; }

    public void Atualizar(
        string? numero,
        double quantidade,
        string? unidadeComercial,
        decimal precoUnitarioCompra,
        DateTime? dataFabricacao,
        DateTime? dataValidade,
        DateTime? dataEntrada)
    {
        Numero = numero;
        Quantidade = quantidade;
        UnidadeComercial = unidadeComercial;
        PrecoUnitarioCompra = precoUnitarioCompra;
        DataFabricacao = dataFabricacao;
        DataValidade = dataValidade;
        DataEntrada = dataEntrada;
    }

    #region Relacionamento

    public ICollection<Produto>? Produtos { get; set; }
    public ICollection<FornecedorLote>? FornecedorLote { get; set; }
    public ICollection<EstoqueLote>? EstoqueLote { get; set; }
    //public ICollection<MovimentacaoEstoque>? MovimentacaoEstoques { get; set; }

    #endregion
}
