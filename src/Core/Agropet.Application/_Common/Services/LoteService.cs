using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services;

public class LoteService : ServiceBase<Domain.Entities.Lote>, ILoteService
{
    public LoteService(ILoteRepository loteRepository) : base(loteRepository)
    {
    }
}
