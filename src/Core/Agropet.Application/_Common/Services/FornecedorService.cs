using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services;

public class FornecedorService : ServiceBase<Domain.Entities.Fornecedor>, IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }
}
