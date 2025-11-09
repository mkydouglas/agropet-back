namespace Agropet.Domain.Entities;

public class Produto : BaseEntity
{
    public string Nome { get; set; } = null!;
    public int Codigo { get; set; }
    public long CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoVenda { get; set; }

    public void CalcularPrecoVenda(decimal precoCompra, double margemGlobal)
    {
        if(PrecoVenda == 0)
        {
            var margem = Margem == 0 ? margemGlobal : Margem;
            PrecoVenda = precoCompra + precoCompra * (decimal)margem;
        }
    }

    #region Relacionamento

    public int IdUsuario { get; set; }
    public Usuario? Usuario { get; set; }
    //public ICollection<Lote>? Lotes { get; set; }
    //public ICollection<MovimentacaoEstoque>? MovimentacaoEstoques { get; set; }
    //public ICollection<ProdutoVenda>? ProdutoVendas { get; set; }

    #endregion
}
