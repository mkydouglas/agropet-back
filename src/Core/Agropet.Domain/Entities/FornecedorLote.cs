using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Entities;

public class FornecedorLote : BaseEntity
{
    public FornecedorLote(Fornecedor fornecedor, Lote lote)
    {
        Fornecedor = fornecedor;
        Lote = lote;
    }

    public int IdFornecedor { get; private set; }
    public Fornecedor? Fornecedor { get; private set; }

    public int IdLote { get; private set; }
    public Lote? Lote { get; private set; }
}
