using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Lote.Commands;

public sealed record DeletarLoteCommand : IRequest<Resposta>
{
    public int Id { get; set; }
}