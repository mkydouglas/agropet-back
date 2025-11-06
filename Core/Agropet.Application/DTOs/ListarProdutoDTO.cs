using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.DTOs;

public class ListarProdutoDTO
{
    public string Nome { get; set; } = null!;
    public int Codigo { get; set; }
    public long CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoVenda { get; set; }
    public List<LoteDTO>? LotesDTO { get; set; } = new List<LoteDTO>();
}
