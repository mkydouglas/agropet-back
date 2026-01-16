using Agropet.Application.Configuracao.Commands;
using Agropet.Application.Configuracao.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Agropet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfiguracaoController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var resposta = await _mediator.Send(new ListarConfiguracaoQuery());
        return StatusCode(resposta.StatusCode, resposta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody]AtualizarConfiguracaoCommand command)
    {
        if (id != command.Id)
            return BadRequest("Id da URL e do corpo não conferem.");

        var resposta = await _mediator.Send(command);
        return StatusCode(resposta.StatusCode, resposta);
    }
}
