using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Produto.Queries;

public sealed record ListarProdutosQuery : IRequest<Resposta>;