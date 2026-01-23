using Agropet.Application.Common.Interfaces;
using Agropet.Application.Common.Response;
using Agropet.Application.Venda.Commands;
using Agropet.Application.Venda.Inputs;
using Agropet.Application.Venda.Services;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System.Net;

namespace Agropet.Application.Venda.Handlers;

public sealed class CadastrarVendaCommandHandler(
    IProcessadorVenda _processadorVenda
    ) : IRequestHandler<CadastrarVendaCommand, Resposta>
{
    public async Task<Resposta> Handle(CadastrarVendaCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.ProdutosVendidosInput == null || request.FormaPagamentoInput == null)
            return new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Por favor, envie os produtos vendidos");

        //var usuario = await _usuarioRepository.ObterAsync(request.UserId);
        var input = new ProcessarVendaInput(request.UserId, 1, request.ProdutosVendidosInput, request.QtdeTotalItens, request.ValorTotal, request.ValorPago, request.Desconto, request.FormaPagamentoInput);
        await _processadorVenda.ProcessarAsync(input, cancellationToken);

        return new Resposta((int)HttpStatusCode.Created);
    }
}