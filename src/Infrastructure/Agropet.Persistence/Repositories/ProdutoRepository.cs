using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Agropet.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agropet.Infrastructure.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Produto?> ObterPorCodigoBarrasAsync(string codigoBarras) => await _context.Produto.FirstOrDefaultAsync(p => p.CodigoBarras == codigoBarras);
    public async Task<List<Produto>> ListarPorCodigoBarrasAsync(List<string> codigosDeBarra)
    {
        return await _context.Produto
            .Where(p => codigosDeBarra.Contains(p.CodigoBarras))
            .Include(p => p.Lotes)
            .Include(p => p.FornecedorProdutos)
            .Include(p => p.EstoqueProdutos)
            .ToListAsync();
    }

    async Task<List<Produto>> IProdutoRepository.ListarAsync()
    {
        return await _context.Produto
            .Include(p => p.Lotes)
            .Include(p => p.FornecedorProdutos)
                .ThenInclude(fp => fp.Fornecedor)
            .Include(p => p.EstoqueProdutos)
            .ToListAsync();
    }
}
