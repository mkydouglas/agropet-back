using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Produto.Commands;

public sealed record DeletarProdutoCommand(int Id) : IRequest<Resposta>;
