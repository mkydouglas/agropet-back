using Agropet.Application.Venda.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class VendaController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(CadastrarVendaCommand command)
    {
        var response = await _mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }
}
