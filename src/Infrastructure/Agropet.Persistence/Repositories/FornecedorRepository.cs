using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agropet.Infrastructure.Repositories;
public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
{
    private readonly AppDbContext _context;

    public FornecedorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<Fornecedor?> ObterPorCnpjAsync(string cnpj) => _context.Fornecedor.FirstOrDefaultAsync(f => f.CNPJ == cnpj);
}
