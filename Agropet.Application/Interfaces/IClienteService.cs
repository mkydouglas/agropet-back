using Agropet.Application.DTOs;
using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Interfaces
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        Cliente Obter(string cpf);
        ClienteDto Criar(ClienteDto clienteDto);
        ClienteDto Atualizar(ClienteDto clienteDto);
    }
}
