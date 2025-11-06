using Agropet.Application.DTOs;
using Agropet.Application.Response;

namespace Agropet.Application.Interfaces;

public interface IEntradaService
{
    Task<Resposta> CadastrarManual(EntradaDTO entrada);
    Task<Resposta> CadastrarViaNF(Stream stream);
}
