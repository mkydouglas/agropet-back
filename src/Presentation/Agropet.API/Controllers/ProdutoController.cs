//using Agropet.Application.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace Agropet.API.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class ProdutoController : ControllerBase
//{
//    private readonly IProdutoService _produtoService;

//    public ProdutoController(IProdutoService produtoService)
//    {
//        _produtoService = produtoService;
//    }

//    [HttpGet("listar")]
//    public async Task<IActionResult> Listar()
//    {
//        return Ok(_produtoService.Listar());
//    }
//}
