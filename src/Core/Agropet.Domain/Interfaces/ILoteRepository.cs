using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Interfaces;

public interface ILoteRepository : IBaseRepository<Lote>
{
    Task<Dictionary<string, Lote>> ListarPorNumeroAsync(List<string> numeroLotes);
    void CriarRange(List<Lote> lotes);
}
