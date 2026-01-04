using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Compra.Commands;

public sealed record CadastrarCompraViaNFCommand(Stream Stream) : CommandQueryBase, IRequest<Resposta>;
