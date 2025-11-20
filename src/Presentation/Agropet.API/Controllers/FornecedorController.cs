using Agropet.Application.UseCases.Fornecedor.Commands;
using Agropet.Application.UseCases.Fornecedor.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agropet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FornecedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarFornecedorCommand command)
        {
            var resposta = await _mediator.Send(command);
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarFornecedorCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id da URL e do corpo não conferem.");

            var resposta = await _mediator.Send(command);
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var resposta = await _mediator.Send(new DeletarFornecedorCommand { Id = id });
            return StatusCode(resposta.StatusCode, resposta);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resposta = await _mediator.Send(new ListarFornecedorQuery());
            return StatusCode(resposta.StatusCode, resposta);
        }
    }
}
