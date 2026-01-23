using Agropet.Application.Venda.Inputs;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Mapster;

namespace Agropet.Application.Venda.Services;

public class ProcessadorVenda(
    IVendaRepository _vendaRepository,
    IEstoqueProdutoRepository _estoqueProdutoRepository,
    IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository,
    IUnitOfWork _unitOfWork,
    ILoteRepository _loteRepository
    ) : IProcessadorVenda
{
    public async Task<Domain.Entities.Venda> ProcessarAsync(ProcessarVendaInput processarVendaInput, CancellationToken cancellationToken)
    {
        var venda = _vendaRepository.Criar(processarVendaInput.Adapt<Domain.Entities.Venda>());
        venda.VincularUsuario(processarVendaInput.IdUsuario);

        var produtosVendidos = processarVendaInput.ProdutosVendidosInput.Adapt<List<ItemVenda>>();
        var idProdutos = produtosVendidos.Select(x => x.IdProduto).ToList();
        var estoqueProdutos = await _estoqueProdutoRepository.ListarAsync(idProdutos, processarVendaInput.IdEstoque);
        var estoqueProdutosDictionary = estoqueProdutos.ToDictionary(ep => ep.IdProduto);
        var lotes = await _loteRepository.ObterLotesPorFifo(idProdutos);
        var lotesPorProduto = lotes.GroupBy(l => l.IdProduto).ToDictionary(g => g.Key, g => g.ToList());

        foreach (var produtoVendido in produtosVendidos)
        {
            venda.AdicionarProdutoVendido(produtoVendido);
            var estoqueProduto = estoqueProdutosDictionary[produtoVendido.IdProduto];
            if (estoqueProduto == null)
                throw new Exception();

            estoqueProduto.Sair(produtoVendido.Quantidade);
            _estoqueProdutoRepository.Atualizar(estoqueProduto);

            lotesPorProduto.TryGetValue(produtoVendido.IdProduto, out var lote);
            if(lote != null)
                BaixarEstoquePorFifo(produtoVendido.Quantidade, lote);

            var movimentacao = MovimentacaoEstoque.CriarSaidaPorVenda(produtoVendido.IdProduto, processarVendaInput.IdEstoque, venda, produtoVendido.Quantidade, lote?.FirstOrDefault()?.Id);
            _movimentacaoEstoqueRepository.Criar(movimentacao);
        }

        var vendaFormaPagamento = processarVendaInput.FormaPagamentoInput.Adapt<List<VendaFormaPagamento>>();
        foreach (var formaPagamento in vendaFormaPagamento)
        {
            venda.AdicionarFormaPagamento(formaPagamento);
        }

        await _unitOfWork.Commit(cancellationToken);

        return venda;
    }

    public void BaixarEstoquePorFifo(int quantidadeVendida, IEnumerable<Domain.Entities.Lote> lotes)
    {
        var restante = quantidadeVendida;

        foreach (var lote in lotes)
        {
            if (restante <= 0)
                break;

            if (lote.Quantidade >= restante)
            {
                lote.Sair(restante);
                restante = 0;
            }
            else
            {
                restante -= lote.Quantidade;
                lote.Sair(lote.Quantidade);
            }
        }

        if (restante > 0)
            throw new Exception("Estoque insuficiente nos lotes.");
            //throw new DomainException("Estoque insuficiente nos lotes.");
    }
}
