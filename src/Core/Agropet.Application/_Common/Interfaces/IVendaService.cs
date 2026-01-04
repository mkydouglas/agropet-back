using Agropet.Application.Common.DTOs;
using Agropet.Application.Common.Response;
using Agropet.Domain.Entities;

namespace Agropet.Application.Common.Interfaces;

public interface IVendaService : IServiceBase<Venda>
{
    Task<Resposta> Cadastrar(VendaDTO vendaDTO);
}
