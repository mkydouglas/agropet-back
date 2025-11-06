using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EntradaController : ControllerBase
{
    private readonly IEntradaService _entradaService;

    public EntradaController(IEntradaService entradaService)
    {
        _entradaService = entradaService;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(EntradaDTO entradaDTO)
    {
        var response = await _entradaService.CadastrarManual(entradaDTO);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost("cadastro-via-nf")]
    public async Task<IActionResult> Cadastrar(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Nenhum arquivo enviado.");

        if (!file.FileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            return BadRequest("Arquivo não é um XML.");

        using var stream = file.OpenReadStream();

        var response = await _entradaService.CadastrarViaNF(stream);
        return StatusCode(response.StatusCode, response);
    }
}
