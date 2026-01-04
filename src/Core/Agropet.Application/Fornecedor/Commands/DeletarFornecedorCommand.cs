using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Fornecedor.Commands;

public sealed record DeletarFornecedorCommand : IRequest<Resposta>
{
    public int Id { get; set; }
}