using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
