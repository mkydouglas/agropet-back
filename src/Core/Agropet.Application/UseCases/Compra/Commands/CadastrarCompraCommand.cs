using Agropet.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Compra.Commands;

public sealed record CadastrarCompraCommand : IRequest<Resposta>
{
    public int IdUsuario { get; set; }
    public int IdFornecedor { get; set; }
    public string? NumeroNotaFiscal { get; set; }
    public List<ItensComprados> ItensComprados { get; set; } = [];
}

public sealed record ItensComprados
{
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}
