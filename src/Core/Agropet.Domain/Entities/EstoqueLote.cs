using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Entities;

public class EstoqueLote : BaseEntity
{
    public int IdEstoque { get; set; }
    public Estoque? Estoque { get; set; }

    public int IdLote { get; set; }
    public Lote? Lote { get; set; }

    public int QuantidadeProduto { get; set; }
}
