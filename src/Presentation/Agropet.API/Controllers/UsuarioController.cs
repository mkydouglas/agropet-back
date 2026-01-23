using Agropet.Application.Usuario.Commands;
using Agropet.Application.Usuario.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers
{
    [Route("api/v1/[controller]")]
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
            return StatusCode(resposta.StatusCode, resposta);
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
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var resposta = await _mediator.Send(new ListarUsuarioQuery());
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var resposta = await _mediator.Send(new DeletarUsuarioCommand(id));
            return StatusCode(resposta.StatusCode, resposta);
        }

        //[HttpGet("{cpf}")]
        //public IActionResult Obter(string cpf)
        //{
        //    return Ok(_usuarioService.Obter(cpf));
        //}
    }
}
