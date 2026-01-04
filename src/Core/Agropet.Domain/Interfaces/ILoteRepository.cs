using Agropet.Domain.Entities;

namespace Agropet.Domain.Interfaces;

public interface ILoteRepository : IBaseRepository<Lote>
{
    Task<Dictionary<string, Lote>> ListarPorNumeroAsync(List<string> numeroLotes);
    void CriarRange(List<Lote> lotes);
}
