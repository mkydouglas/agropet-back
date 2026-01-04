using Agropet.Application.Common.DTOs;
using Agropet.Application.Common.Response;

namespace Agropet.Application.Common.Interfaces;

public interface IEntradaService
{
    Task<Resposta> CadastrarManual(EntradaDTO entrada);
    Task<Resposta> CadastrarViaNF(Stream stream);
}
