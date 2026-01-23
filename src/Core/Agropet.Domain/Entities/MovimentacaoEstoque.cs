using Agropet.Domain.Enums;

namespace Agropet.Domain.Entities;

public class MovimentacaoEstoque : BaseEntity
{
    public ETipoMovimentacaoEstoque Tipo { get; private set; }
    public double Quantidade { get; private set; }
    public DateTime DataMovimentacao { get; private set; }

    public int IdProduto { get; private set; }
    public Produto Produto { get; private set; } = null!;

    public int IdEstoque { get; private set; }
    public Estoque Estoque { get; private set; } = null!;

    public int? IdCompra { get; private set; }
    public Compra? Compra { get; private set; }

    public int? IdVenda { get; private set; }
    public Venda? Venda { get; private set; }

    public int? IdLote { get; private set; }
    public Lote? Lote { get; private set; }

    private MovimentacaoEstoque() { }

    public static MovimentacaoEstoque CriarEntradaPorCompra(
        Produto produto,
        Estoque estoque,
        Compra compra,
        double quantidade,
        Lote? lote = null)
    {
        return new MovimentacaoEstoque
        {
            Tipo = ETipoMovimentacaoEstoque.Entrada,
            Quantidade = quantidade,
            DataMovimentacao = DateTime.Now,
            Produto = produto,
            Estoque = estoque,
            Compra = compra,
            Lote = lote
        };
    }

    public static MovimentacaoEstoque CriarSaidaPorVenda(
        int produtoId,
        int estoqueId,
        Venda venda,
        double quantidade,
        int? loteId = null)
    {
        return new MovimentacaoEstoque
        {
            Tipo = ETipoMovimentacaoEstoque.Saida,
            Quantidade = quantidade,
            DataMovimentacao = DateTime.Now,
            IdProduto = produtoId,
            IdEstoque = estoqueId,
            Venda = venda,
            IdLote = loteId
        };
    }
}