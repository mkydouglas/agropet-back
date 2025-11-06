using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Services;

public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public int Cadastrar(FornecedorDTO fornecedorDTO)
    {
        if (fornecedorDTO == null)
            return 0;

        var fornecedor = _fornecedorRepository.ObterPorCnpj(fornecedorDTO.CNPJ ?? "");
        if (fornecedor == null)
        {
            fornecedor = Criar((Fornecedor)fornecedorDTO);
        }

        return fornecedor.Id;
    }
}
