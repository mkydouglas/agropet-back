using Agropet.Application.FormaPagamento.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FormaPagamentoController : ControllerBase
{
    private readonly IMediator _mediator;

    public FormaPagamentoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var resposta = await _mediator.Send(new ListarFormaPagamentoQuery());
        return StatusCode(resposta.StatusCode, resposta);
    }
}
