using Agropet.Application.Compra.Inputs;

namespace Agropet.Application.Compra.Services;

public interface IProcessadorCompra
{
    Task<Domain.Entities.Compra> ProcessarAsync(CadastrarCompraInput cadastrarCompraInput, CancellationToken cancellationToken);
}
