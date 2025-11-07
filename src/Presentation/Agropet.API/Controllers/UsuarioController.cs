using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Agropet.Application.Response;
using Agropet.Application.UseCases.Usuario.Commands;
using Agropet.Application.UseCases.Usuario.Queries;
using Agropet.Application.UseCases.Usuario.Responses;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var resposta = await _mediator.Send(new ObterUsuarioQuery(id));
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(AtualizarUsuarioCommand usuario)
        {
            var resposta = await _mediator.Send(usuario);
            return StatusCode(resposta.StatusCode, resposta.Data);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var resposta = await _mediator.Send(new ListarUsuarioQuery());
            return StatusCode(resposta.StatusCode, resposta.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var resposta = await _mediator.Send(new DeletarUsuarioCommand(id));
            return StatusCode(resposta.StatusCode, resposta.Data);
        }

        //[HttpGet("{cpf}")]
        //public IActionResult Obter(string cpf)
        //{
        //    return Ok(_usuarioService.Obter(cpf));
        //}
    }
}
