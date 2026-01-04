using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Entities;

public class Compra : BaseEntity
{
    public Compra()
    {
        
    }

    public Compra(string? numeroNotaFiscal, Usuario usuario, Fornecedor fornecedor, int quantidadeItensComprados, decimal valorTotal = 0)
    {
        NumeroNotaFiscal = numeroNotaFiscal;
        Usuario = usuario;
        Fornecedor = fornecedor;
        QuantidadeItensComprados = quantidadeItensComprados;
        ValorTotal = valorTotal;
    }

    public string? NumeroNotaFiscal { get; private set; }
    public int QuantidadeItensComprados { get; private set; }
    public decimal ValorTotal { get; private set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public int IdUsuario { get; private set; }
    public Usuario Usuario { get; private set; } = null!;
    public int IdFornecedor { get; private set; }
    public Fornecedor Fornecedor { get; private set; } = null!;
    public ICollection<ItemCompra> ItensCompras { get; set; } = [];

    public void SomarAoValorTotal(decimal valor) => ValorTotal += valor;

    public void AdicionarNumeroNotaFiscal(string? numeroNotaFiscal) => NumeroNotaFiscal = numeroNotaFiscal;

    public void AdicionarItem(int quantidade, decimal preco, Produto produto)
    {
        var item = new ItemCompra(quantidade, preco, this, produto);
        ItensCompras.Add(item);
    }
}
