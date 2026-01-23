using Agropet.Application.Venda.Inputs;

namespace Agropet.Application.Venda.Services;

public interface IProcessadorVenda
{
    Task<Domain.Entities.Venda> ProcessarAsync(ProcessarVendaInput processarVendaInput, CancellationToken cancellationToken);
}
