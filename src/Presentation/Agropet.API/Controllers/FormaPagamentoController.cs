using Agropet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormaPagamentoController : ControllerBase
{
    private readonly IFormaPagamentoService _formaPagamentoService;

    public FormaPagamentoController(IFormaPagamentoService formaPagamentoService)
    {
        _formaPagamentoService = formaPagamentoService;
    }

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        return Ok(_formaPagamentoService.Listar());
    }
}
