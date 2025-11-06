using System.ComponentModel.DataAnnotations.Schema;

namespace Agropet.Domain.Entities
{
    public class ProdutoVenda : EntityBase
    {
        public decimal PrecoProduto { get; set; }
        public double Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorPago { get; set; }

        #region Relacionamento

        public int IdProduto { get; set; }
        public Produto? Produto { get; set; }
        public int IdVenda { get; set; }
        public Venda? Venda { get; set; }

        #endregion
    }
}
