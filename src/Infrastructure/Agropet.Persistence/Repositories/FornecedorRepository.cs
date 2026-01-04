using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;

namespace Agropet.Infrastructure.Repositories;
public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
{
    private readonly AppDbContext _context;

    public FornecedorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public Fornecedor? ObterPorCnpj(string cnpj) => _context.Fornecedor.FirstOrDefault(f => f.CNPJ == cnpj);
}
