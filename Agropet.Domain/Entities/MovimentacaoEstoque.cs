using Agropet.Domain.Enums;

namespace Agropet.Domain.Entities;
public class MovimentacaoEstoque : EntityBase
{
    public ETipoMovimentacaoEstoque ETipoMovimentacaoEstoque { get; set; }
    public double Quantidade { get; set; }
    private DateTime DataMovimentacao { get; set; } = DateTime.Now;

    #region Relacionamento

    public int? IdLote { get; set; }
    public Lote? Lote { get; set; }
    public int? IdProduto { get; set; }
    public Produto? Produto { get; set; }

    #endregion
}
