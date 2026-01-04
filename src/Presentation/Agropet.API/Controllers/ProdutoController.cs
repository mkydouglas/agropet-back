using Agropet.Application.Produto.Commands;
using Agropet.Application.Produto.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(CadastrarProdutoCommand command)
    {
        var response = await _mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar(AtualizarProdutoCommand command)
    {
        var response = await _mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete]
    public async Task<IActionResult> Deletar(DeletarProdutoCommand command)
    {
        var response = await _mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        var response = await _mediator.Send(new ListarProdutosQuery());
        return StatusCode(response.StatusCode, response);
    }
}
