using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Agropet.Application.UseCases.Usuario.Commands;
using Agropet.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CadastrarUsuarioCommand usuario)
        {
            var resposta = await _mediator.Send(usuario);
            return StatusCode(resposta.StatusCode, resposta.Data);
        }

        //[HttpGet("{cpf}")]
        //public IActionResult Obter(string cpf)
        //{
        //    return Ok(_usuarioService.Obter(cpf));
        //}

        //[HttpGet("listar")]
        //public IActionResult Listar()
        //{
        //    return Ok(_usuarioService.Listar());
        //}

        //[HttpPut]
        //public IActionResult Atualizar(UsuarioDto usuarioDto)
        //{
        //    return Ok(_usuarioService.Atualizar(usuarioDto));
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Deletar(int id)
        //{
        //    return Ok(_usuarioService.Deletar(id));
        //}
    }
}
