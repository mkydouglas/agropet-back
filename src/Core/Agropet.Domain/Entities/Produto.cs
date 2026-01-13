namespace Agropet.Domain.Entities;

public class Produto : BaseEntity
{
    public string Nome { get; private set; } = null!;
    public string? Codigo { get; private set; }
    public string CodigoBarras { get; private set; } = string.Empty;
    public double Margem { get; private set; }
    public decimal PrecoVenda { get; private set; }
    public string? UnidadeComercial { get; private set; }
    public decimal PrecoUnitarioCompra { get; private set; }

    public Produto AtualizarNome(string nome)
    {
        Nome = nome;
        return this;
    }

    public Produto AtualizarCodigo(string codigo)
    {
        Codigo = codigo;
        return this;
    }

    public Produto AtualizarCodigoBarras(string codigoBarras)
    {
        CodigoBarras = codigoBarras;
        return this;
    }

    public Produto AtualizarMargem(double margem)
    {
        Margem = margem;
        return this;
    }

    public Produto CalcularPrecoVenda(double margemGlobal, decimal precoUnitario)
    {
        if(PrecoVenda == 0)
        {
            var margem = Margem == 0 ? margemGlobal : Margem;
            PrecoVenda = precoUnitario * (decimal)(margem / 100) + precoUnitario;
            PrecoVenda = decimal.Round(PrecoVenda, 2);
        }

        return this;
    }

    public Produto ReferenciarUsuario(Usuario usuario)
    {
        Usuario = usuario;
        return this;
    }

    public Produto ReferenciarFornecedor(Fornecedor fornecedor)
    {
        if (FornecedorProdutos.Any(fp => fp.IdFornecedor == fornecedor.Id && fp.IdProduto == Id))
            return this;

        FornecedorProdutos.Add(new(fornecedor, this));
        return this;
    }

    public Produto ReferenciarEstoque(Estoque estoque, int quantidadeProduto)
    {
        if (EstoqueProdutos.Any(ep => ep.Estoque.Id == estoque.Id && ep.Produto.Id == Id))
        {
            EstoqueProdutos.First(ep => ep.Estoque.Id == estoque.Id && ep.Produto.Id == Id).QuantidadeProduto += quantidadeProduto;
            return this;
        }

        EstoqueProdutos.Add(new(quantidadeProduto, estoque, this));
        return this;
    }

    public Produto AdicionarItem(int quantidade, decimal precoUnitario, Compra compra)
    {
        var item = new ItemCompra(quantidade, precoUnitario, compra, this);
        ItensCompras.Add(item);
        return this;
    }

    #region Relacionamento

    public int IdUsuario { get; set; }
    public Usuario? Usuario { get; set; }
    public ICollection<Lote>? Lotes { get; set; }
    public ICollection<EstoqueProduto> EstoqueProdutos { get; set; } = [];
    public ICollection<FornecedorProduto> FornecedorProdutos { get; set; } = [];
    public ICollection<ItemCompra> ItensCompras { get; set; } = [];
    //public ICollection<MovimentacaoEstoque>? MovimentacaoEstoques { get; set; }
    //public ICollection<ProdutoVenda>? ProdutoVendas { get; set; }

    #endregion
}
