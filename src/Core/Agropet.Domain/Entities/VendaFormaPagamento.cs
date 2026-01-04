namespace Agropet.Domain.Entities;

public class VendaFormaPagamento : BaseEntity
{
    public decimal ValorPago { get; set; }

    #region Relacionamentos

    public int IdVenda { get; set; }
    public Venda? Venda { get; set; }
    public int IdFormaPagamento { get; set; }
    public FormaPagamento? FormaPagamento { get; set; }
    
    #endregion
}
