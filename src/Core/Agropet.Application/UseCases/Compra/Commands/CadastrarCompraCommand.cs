using Agropet.Application.Response;
using Agropet.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Agropet.Application.UseCases.Compra.Commands;

public sealed record CadastrarCompraCommand : CommandQueryBase, IRequest<Resposta>
{
    public string? NumeroNotaFiscal { get; set; }
    public required FornecedorDTO FornecedorDTO { get; set; }
    public required List<ItensComprados> ItensComprados { get; set; }
}

public sealed record FornecedorDTO
{
    public int? Id { get; set; }
    public required string CNPJ { get; set; }
    public required string NomeFantasia { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Telefone { get; set; }
}

public sealed record ItensComprados
{
    public required ProdutoDTO ProdutoDTO { get; set; }
}

public sealed record ProdutoDTO
{
    public int? Id { get; set; }
    public required string Nome { get; set; }
    public string? Codigo { get; set; }
    public required string CodigoBarras { get; set; }
    public double Margem { get; set; }
    public decimal PrecoUnitarioCompra { get; set; }
    public string? UnidadeComercial { get; set; }
    public int Quantidade { get; set; }
    public LoteDTO? LoteDTO { get; set; }
}

public sealed record LoteDTO
{
    public int? Id { get; set; }
    public string? Numero { get; set; }
    public int? Quantidade { get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime? DataValidade { get; set; }
}

