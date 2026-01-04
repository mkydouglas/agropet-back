using Agropet.Application.Common.Interfaces;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;

namespace Agropet.Application.Common.Services;

public class MovimentacaoEstoqueService : ServiceBase<MovimentacaoEstoque>, IMovimentacaoEstoqueService
{
    public MovimentacaoEstoqueService(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository) : base(movimentacaoEstoqueRepository)
    {
    }
}
