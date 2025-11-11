using System.Reflection.Metadata.Ecma335;

namespace Agropet.Domain.Entities;

public class Produto : BaseEntity
{
    public string Nome { get; private set; } = null!;
    public int Codigo { get; private set; }
    public long CodigoBarras { get; private set; }
    public double Margem { get; private set; }
    public decimal PrecoVenda { get; private set; }

    public void CalcularPrecoVenda(decimal precoCompra, double margemGlobal)
    {
        if(PrecoVenda == 0)
        {
            var margem = Margem == 0 ? margemGlobal : Margem;
            PrecoVenda = precoCompra + precoCompra * (decimal)margem;
        }
    }

    public void AtualizarNome(string nome) => Nome = nome;
    public void AtualizarCodigo(int codigo) => Codigo = codigo;
    public void AtualizarCodigoBarras(long codigoBarras) => CodigoBarras = codigoBarras;
    public void AtualizarMargem(double margem) => Margem = margem;

    #region Relacionamento

    public int IdUsuario { get; set; }
    public Usuario? Usuario { get; set; }
    public int IdLote { get; set; }
    public Lote? Lote { get; set; }
    //public ICollection<MovimentacaoEstoque>? MovimentacaoEstoques { get; set; }
    //public ICollection<ProdutoVenda>? ProdutoVendas { get; set; }

    #endregion
}
