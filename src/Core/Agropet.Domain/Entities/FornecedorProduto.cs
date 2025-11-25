using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Entities;

public class FornecedorProduto : BaseEntity
{
    public FornecedorProduto()
    {
        
    }

    public FornecedorProduto(Fornecedor fornecedor, Produto produto)
    {
        Fornecedor = fornecedor;
        Produto = produto;
    }

    public int IdFornecedor { get; private set; }
    public Fornecedor Fornecedor { get; private set; } = null!;
    public int IdProduto { get; private set; }
    public Produto Produto { get; private set; } = null!;
}
