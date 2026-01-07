using Agropet.Domain.Entities;

namespace Agropet.Application.Compra.Inputs;

public sealed record CadastrarCompraInput(
    string? NumeroNotaFiscal, 
    Domain.Entities.Fornecedor Fornecedor, 
    List<ItemCompraInput> ItensComprados,
    Domain.Entities.Usuario Usuario,
    Estoque Estoque);
