using Agropet.Application.Common.Response;
using MediatR;

namespace Agropet.Application.Fornecedor.Queries;

public sealed record ObterFornecedorPorCNPJQuery(string CNPJ) : IRequest<Resposta>;