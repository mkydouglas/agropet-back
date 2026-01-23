namespace Agropet.Domain.Entities;

public class Produto : BaseEntity
{
    public string Nome { get; private set; } = null!;
    public string? Codigo { get; private set; }
    public string CodigoBarras { get; private set; } = string.Empty;
    public double Margem { get; private set; }
    public decimal PrecoVenda { get; private set; }
    public string? UnidadeComercial { get; private set; }

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

    public Produto AtualizarPrecoVenda(decimal novoPreco)
    {
        PrecoVenda = novoPreco;
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

    public EstoqueProduto? ObterEstoqueProduto(Estoque estoque)
    {
        return EstoqueProdutos.FirstOrDefault(ep => ep.Estoque.Id == estoque.Id && ep.Produto.Id == Id);
    }
    
    public Produto AdicionarItem(int quantidade, decimal precoUnitario, Compra compra)
    {
        var item = new ItemCompra(quantidade, precoUnitario, compra, this);
        ItensCompras.Add(item);
        return this;
    }

    public Produto RegistrarMovimentacao(Estoque estoque, Compra compra, int quantidade)
    {
        MovimentacaoEstoques.Add(MovimentacaoEstoque.CriarEntradaPorCompra(this, estoque, compra, quantidade));
        return this;
    }

    public void EntrarNoEstoque(Estoque estoque, int quantidade)
    {
        var estoqueProduto = ObterEstoqueProduto(estoque);

        if (estoqueProduto == null)
            EstoqueProdutos.Add(EstoqueProduto.Criar(Id, estoque.Id, quantidade));
        else
            estoqueProduto.Entrar(quantidade);
    }

    #region Relacionamento

    public int IdUsuario { get; set; }
    public Usuario? Usuario { get; set; }
    public ICollection<Lote>? Lotes { get; set; }
    public ICollection<EstoqueProduto> EstoqueProdutos { get; private set; } = [];
    public ICollection<FornecedorProduto> FornecedorProdutos { get; set; } = [];
    public ICollection<ItemCompra> ItensCompras { get; set; } = [];
    public ICollection<MovimentacaoEstoque> MovimentacaoEstoques { get; set; } = [];
    public ICollection<ItemVenda>? ItemVendas { get; set; }

    #endregion
}
