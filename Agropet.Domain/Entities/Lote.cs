namespace Agropet.Domain.Entities;

public class Lote : EntityBase
{
    public string? Numero { get; set; }
    public double Quantidade { get; set; }
    public string? UnidadeComercial { get; set; }
    public decimal PrecoUnitarioCompra { get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime? DataValidade { get; set; }
    public DateTime? DataEntrada { get; set; }
    public int IdProduto { get; set; }
    public int IdFornecedor { get; set; }

    #region Relacionamento

    public Produto? Produto { get; set; }
    public Fornecedor? Fornecedor { get; set; }
    public ICollection<MovimentacaoEstoque>? MovimentacaoEstoques { get; set; }

    #endregion
}
