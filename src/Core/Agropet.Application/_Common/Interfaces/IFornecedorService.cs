using Agropet.Application._Common.DTOs;
namespace Agropet.Application.Common.Interfaces;

public interface IFornecedorService : IServiceBase<Domain.Entities.Fornecedor>
{
    Task<Domain.Entities.Fornecedor> GarantirExistenciaAsync(FornecedorDTO fornecedorDTO, int idUsuarioCadastro);
}
