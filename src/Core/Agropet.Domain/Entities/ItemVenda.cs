namespace Agropet.Domain.Entities
{
    public class ItemVenda : BaseEntity
    {
        public decimal PrecoProduto { get; set; }
        public int Quantidade { get; set; }
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
