using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Entities;

public class FormaPagamento : EntityBase
{
    public string Nome { get; set; } = null!;

    #region Relacionamentos

    public ICollection<VendaFormaPagamento>? VendaFormaPagamento { get; set; }

    #endregion
}
