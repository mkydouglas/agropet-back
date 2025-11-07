//using Agropet.Application.DTOs;
//using Agropet.Application.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace Agropet.API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class VendaController : ControllerBase
//{
//    private readonly IVendaService _vendaService;

//    public VendaController(IVendaService vendaService)
//    {
//        _vendaService = vendaService;
//    }

//    [HttpPost]
//    public async Task<IActionResult> Cadastrar(VendaDTO vendaDTO)
//    {
//        var response = await _vendaService.Cadastrar(vendaDTO);
//        return StatusCode(response.StatusCode, response);
//    }
//}
