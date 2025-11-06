using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{cpf}")]
        public IActionResult Obter(string cpf)
        {
            return Ok(_clienteService.Obter(cpf));
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_clienteService.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteDto clienteDto)
        {
            return Ok(_clienteService.Criar(clienteDto));
        }

        [HttpPut]
        public IActionResult Atualizar(ClienteDto clienteDto)
        {
            return Ok(_clienteService.Atualizar(clienteDto));
        }

        //TODO: Trocar id por cpf. precisa criar o método
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            return Ok(_clienteService.Deletar(id));
        }
    }
}
