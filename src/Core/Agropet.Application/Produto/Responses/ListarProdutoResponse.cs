using System;
using System.Collections.Generic;
using System.Text;

namespace Agropet.Application.Produto.Responses;

public sealed record ListarProdutoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Codigo { get; set; }
    public string CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoVenda { get; set; }
    public string? UnidadeComercial { get; set; }
    public int QuantidadeProduto { get; set; }
    public List<string> NomeFantasiaFornecedores { get; set; } = null!;
}
