using Agropet.Application.Common.DTOs;
using Agropet.Domain.Entities;

namespace Agropet.Application.Common.Interfaces
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        Cliente Obter(string cpf);
        ClienteDto Criar(ClienteDto clienteDto);
        ClienteDto Atualizar(ClienteDto clienteDto);
    }
}
