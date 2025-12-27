using Agropet.Application.UseCases.Compra.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
//[Authorize]
public class CompraController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompraController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("cadastro-manual")]
    public async Task<IActionResult> Cadastrar(CadastrarCompraCommand command)
    {
        var resposta = await _mediator.Send(command);
        return StatusCode(resposta.StatusCode, resposta);
    }

    [HttpPost("cadastro-via-nf")]
    public async Task<IActionResult> Cadastrar(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Nenhum arquivo enviado.");

        if (!file.FileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            return BadRequest("Arquivo não é um XML.");

        using var stream = file.OpenReadStream();

        var response = await _mediator.Send(new CadastrarCompraViaNFCommand(stream));
        return StatusCode(response.StatusCode, response);
    }
}
