using Agropet.Application.Compra.Inputs;
using Agropet.Domain.Interfaces;
using Mapster;

namespace Agropet.Application.Compra.Services;

public class ProcessadorCompra(
    IProdutoRepository _produtoRepository,
    ILoteRepository _loteRepository,
    ICompraRepository _compraRepository,
    IUnitOfWork _unitOfWork,
    IConfiguracaoRepository _configuracaoRepository
    ) : IProcessadorCompra
{
    public async Task<Domain.Entities.Compra> ProcessarAsync(CadastrarCompraInput cadastrarCompraInput, CancellationToken cancellationToken)
    {
        var config = await _configuracaoRepository.ObterPorNome(Domain.Enums.ENomeConfiguracao.MargemGlobal);
        var compra = new Domain.Entities.Compra(cadastrarCompraInput.NumeroNotaFiscal, cadastrarCompraInput.Usuario, cadastrarCompraInput.Fornecedor, cadastrarCompraInput.ItensComprados.Count);

        var codigoBarrasProdutos = cadastrarCompraInput.ItensComprados.Select(i => i.ProdutoInput.CodigoBarras).ToList();
        var produtosExistentes = await _produtoRepository.ListarPorCodigoBarrasAsync(codigoBarrasProdutos);
        var produtosExistentesPorCodigoBarras = produtosExistentes.ToDictionary(pe => pe.CodigoBarras);

        var nlotes = cadastrarCompraInput.ItensComprados
            .Select(i => i.LoteInput?.Numero)
            .Where(n => !string.IsNullOrWhiteSpace(n))
            .Select(n => n!.ToLower())
            .Distinct()
            .ToList();

        var lotesExistentes = await _loteRepository.ListarPorNumeroAsync(nlotes);

        foreach (var itemCompraInput in cadastrarCompraInput.ItensComprados)
        {
            if (!produtosExistentesPorCodigoBarras.TryGetValue(itemCompraInput.ProdutoInput.CodigoBarras, out var produto))
                produto = itemCompraInput.ProdutoInput.Adapt<Domain.Entities.Produto>();

            var quantidade = itemCompraInput.Quantidade;
            var valorTotal = itemCompraInput.PrecoUnitario * quantidade;
            compra.SomarAoValorTotal(valorTotal);

            EnriquecerProduto(cadastrarCompraInput, produto, compra, quantidade, itemCompraInput.PrecoUnitario, config.ObterValor());

            if (produto.Id > 0)
                _produtoRepository.Atualizar(produto);
            else
                _produtoRepository.Criar(produto);

            if (itemCompraInput.LoteInput == null)
                continue;

            var numeroLote = itemCompraInput.LoteInput.Numero?.Trim().ToLower();

            if (!string.IsNullOrEmpty(numeroLote) &&  lotesExistentes.TryGetValue(numeroLote, out var loteExistente))
                AtualizarLote(quantidade, loteExistente);
            else
                CriarNovoLote(itemCompraInput.LoteInput, produto);
        }

        _compraRepository.Criar(compra);

        await _unitOfWork.Commit(cancellationToken);

        return compra;
    }

    private void AtualizarLote(int quantidade, Domain.Entities.Lote loteExistente)
    {
        loteExistente.AtualizarQuantidade(quantidade);
        _loteRepository.Atualizar(loteExistente);
    }

    private void CriarNovoLote(LoteInput loteInput, Domain.Entities.Produto produto)
    {
        var novoLote = loteInput.Adapt<Domain.Entities.Lote>();
        if (novoLote == null)
            return;

        novoLote.ReferenciarProduto(produto);
        _loteRepository.Criar(novoLote);
    }

    private void EnriquecerProduto(CadastrarCompraInput cadastrarCompraInput, Domain.Entities.Produto produto, Domain.Entities.Compra compra, int quantidade, decimal valorUnitario, double margemGlobal)
    {
        produto
            .CalcularPrecoVenda(margemGlobal, valorUnitario)
            .ReferenciarUsuario(cadastrarCompraInput.Usuario)
            .ReferenciarFornecedor(cadastrarCompraInput.Fornecedor)
            .ReferenciarEstoque(cadastrarCompraInput.Estoque, quantidade)
            .AdicionarItem(quantidade, valorUnitario, compra);
    }
}
