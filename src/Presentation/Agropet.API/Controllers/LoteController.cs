using Agropet.Application.UseCases.Lote.Commands;
using Agropet.Application.UseCases.Lote.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agropet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarLoteCommand command)
        {
            var resposta = await _mediator.Send(command);
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarLoteCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id da URL e do corpo não conferem.");

            var resposta = await _mediator.Send(command);
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var resposta = await _mediator.Send(new DeletarLoteCommand { Id = id });
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resposta = await _mediator.Send(new ListarLoteQuery());
            return StatusCode(resposta.StatusCode, resposta);
        }
    }
}
