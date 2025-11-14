using Agropet.Application.Response;
using MediatR;

namespace Agropet.Application.UseCases.Lote.Commands;

public sealed record DeletarLoteCommand : IRequest<Resposta>
{
    public int Id { get; set; }
}