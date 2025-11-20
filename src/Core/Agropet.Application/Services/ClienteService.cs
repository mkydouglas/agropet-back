using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioService _usuarioService;

        public ClienteService(
            IClienteRepository clienteRepository,
            IUsuarioService usuarioService) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _usuarioService = usuarioService;
        }

        //TODO: Criar classe de resposta
        public Cliente Obter(string cpf)
        {
            return _clienteRepository.Obter(cpf);
        }

        public ClienteDto Criar(ClienteDto clienteDto)
        {
            var usuario = _usuarioService.Obter(clienteDto.CPFUsuarioCadastro);
            if(usuario != null)
            {
                //var cliente = _clienteRepository.Criar(new Cliente(clienteDto.Nome, clienteDto.CPF, usuario.Id));
                return clienteDto;
            }

            return clienteDto;
        }

        public ClienteDto Atualizar(ClienteDto clienteDto)
        {
            var cliente = _clienteRepository.Obter(clienteDto.CPF);
            if (cliente != null)
            {
                //TODO: adicionar automapper
                cliente = _clienteRepository.Atualizar(new Cliente(cliente.Id, clienteDto.Nome, clienteDto.CPF, cliente.IdUsuario));
                return clienteDto;
            }

            return clienteDto;
        }
    }
}
