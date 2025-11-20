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

    public Compra(string? numeroNotaFiscal, Usuario usuario, Fornecedor fornecedor)
    {
        NumeroNotaFiscal = numeroNotaFiscal;
        Usuario = usuario;
        Fornecedor = fornecedor;
    }

    public string? NumeroNotaFiscal { get; private set; }

    public int IdUsuario { get; private set; }
    public Usuario Usuario { get; private set; } = null!;
    public int IdFornecedor { get; private set; }
    public Fornecedor Fornecedor { get; private set; } = null!;
    public ICollection<ItemCompra> ItensCompras { get; set; } = [];

    public void AdicionarNumeroNotaFiscal(string? numeroNotaFiscal) => NumeroNotaFiscal = numeroNotaFiscal;

    public void AdicionarItem(int quantidade, decimal preco, Produto produto)
    {
        var item = new ItemCompra(quantidade, preco, this, produto);
        ItensCompras.Add(item);
    }
}
