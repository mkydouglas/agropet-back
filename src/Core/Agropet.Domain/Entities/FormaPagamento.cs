namespace Agropet.Domain.Entities;

public class FormaPagamento : BaseEntity
{
    public string Nome { get; set; } = null!;

    #region Relacionamentos

    public ICollection<VendaFormaPagamento>? VendaFormaPagamento { get; set; }

    #endregion
}
