using Agropet.Application._Common.DTOs;
using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Interfaces;
using Mapster;

namespace Agropet.Application.Common.Services;

public class FornecedorService : ServiceBase<Domain.Entities.Fornecedor>, IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task<Domain.Entities.Fornecedor> GarantirExistenciaAsync(FornecedorDTO fornecedorDTO, int idUsuarioCadastro)
    {
        var fornecedor = await _fornecedorRepository.ObterPorCnpjAsync(fornecedorDTO.CNPJ);
        if (fornecedor == null)
        {
            fornecedor = fornecedorDTO.Adapt<Domain.Entities.Fornecedor>();
            fornecedor.ReferenciarUsuario(idUsuarioCadastro);
            fornecedor = _fornecedorRepository.Criar(fornecedor);
        }

        return fornecedor;
    }
}
