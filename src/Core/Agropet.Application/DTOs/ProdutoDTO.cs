using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.DTOs;

public class ProdutoDTO
{
    public string Nome { get; set; } = null!;
    public int Codigo { get; set; }
    public long CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoVenda { get; set; }
    public LoteDTO? LoteDTO { get; set; }

    //public static explicit operator Produto(ProdutoDTO dto)
    //{
    //    return new Produto()
    //    {
    //        Codigo = dto.Codigo,
    //        CodigoBarras = dto.CodigoBarras,
    //        Margem = dto.Margem,
    //        Nome = dto.Nome,
    //        PrecoVenda = dto.PrecoVenda
    //    };
    //}
}
