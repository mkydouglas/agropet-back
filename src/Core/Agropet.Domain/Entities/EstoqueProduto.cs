using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Entities;

public class EstoqueProduto : BaseEntity
{
    public int QuantidadeProduto { get; set; }

    public int IdEstoque { get; set; }
    public Estoque Estoque { get; set; } = null!;

    public int IdProduto { get; set; }
    public Produto Produto { get; set; } = null!;

}
