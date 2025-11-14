using Agropet.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Fornecedor.Commands;

public sealed record DeletarFornecedorCommand : IRequest<Resposta>
{
    public int Id { get; set; }
}