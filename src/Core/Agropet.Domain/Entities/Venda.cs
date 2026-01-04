namespace Agropet.Domain.Entities
{
    public class Venda : BaseEntity
    {
        public int QtdeTotalItens { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorPago { get; set; }

        //public int IdUsuario { get; set; }
        //public int IdCliente { get; set; }

        #region Relacionamentos

        //public Usuario Usuario { get; set; }
        //public Cliente Cliente { get; set; }
        public ICollection<ProdutoVenda>? ProtudoVendas { get; set; }
        public ICollection<VendaFormaPagamento>? VendaFormaPagamento { get; set; }

        #endregion
    }
}
