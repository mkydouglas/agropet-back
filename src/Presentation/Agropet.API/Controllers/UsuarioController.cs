using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Agropet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agropet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto usuario)
        {
            //TODO: Remover visibilidade de Dominio
            return Ok(_usuarioService.Criar(new Usuario { Nome = usuario.Nome, CPF = usuario.CPF, Senha = usuario.Senha }));
        }

        [HttpGet("{cpf}")]
        public IActionResult Obter(string cpf)
        {
            return Ok(_usuarioService.Obter(cpf));
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_usuarioService.Listar());
        }

        [HttpPut]
        public IActionResult Atualizar(UsuarioDto usuarioDto)
        {
            return Ok(_usuarioService.Atualizar(usuarioDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(_usuarioService.Deletar(id));
        }
    }
}
