using Agropet.Domain.Entities;

namespace Agropet.Domain.Tests.Entities;

public class CompraTest
{
    [Fact]
    public void Deve_criar_uma_compra()
    {
        //Arrange
        var usuario = new Usuario();
        var fornecedor = new Fornecedor();
        var numeroNotaFiscal = "nfe111233546545654684";
        var quantidade = 2;
        var valorTotal = 100m;

        //Act
        var compra = new Compra(numeroNotaFiscal, usuario, fornecedor, quantidade, valorTotal);

        Assert.Equal(numeroNotaFiscal, compra.NumeroNotaFiscal);
        Assert.Equal(usuario, compra.Usuario);
        Assert.Equal(fornecedor, compra.Fornecedor);
        Assert.Equal(quantidade, compra.QuantidadeItensComprados);
        Assert.Equal(valorTotal, compra.ValorTotal);
        Assert.Empty(compra.ItensCompras);
    }

    [Fact]
    public void Deve_somar_valor_ao_valor_total()
    {
        var compra = new Compra(null, new Usuario(), new Fornecedor(), 1, 100m);

        compra.SomarAoValorTotal(50m);

        Assert.Equal(150m, compra.ValorTotal);
    }

    [Fact]
    public void Deve_adicionar_numero_da_nota_fiscal()
    {
        var compra = new Compra(null, new Usuario(), new Fornecedor(), 1);

        compra.AdicionarNumeroNotaFiscal("NF-123");

        Assert.Equal("NF-123", compra.NumeroNotaFiscal);
    }

    [Fact]
    public void Deve_adicionar_item_a_compra()
    {
        var compra = new Compra(null, new Usuario(), new Fornecedor(), 1);
        var produto = new Produto();

        compra.AdicionarItem(2, 10m, produto);

        Assert.Single(compra.ItensCompras);
    }

}
