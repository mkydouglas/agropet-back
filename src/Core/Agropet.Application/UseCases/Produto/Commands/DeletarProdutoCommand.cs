using Agropet.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Produto.Commands;

public sealed record DeletarProdutoCommand(int Id) : IRequest<Resposta>;
