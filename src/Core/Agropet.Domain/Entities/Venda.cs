namespace Agropet.Domain.Entities
{
    public class Venda : BaseEntity
    {
        public Venda()
        {
            
        }

        public Venda(int qtdeTotalItens, decimal valorTotal, decimal valorPago, decimal desconto = 0)
        {
            QtdeTotalItens = qtdeTotalItens;
            ValorTotal = valorTotal;
            Desconto = desconto;
            ValorPago = valorPago;
        }

        public int QtdeTotalItens { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorPago { get; private set; }
        public DateTime Data { get; private set; } = DateTime.Now;

        public Venda AdicionarProdutoVendido(ItemVenda produtoVendido)
        {
            produtoVendido.Venda = this;
            ItemVendas.Add(produtoVendido);
            return this;
        }

        public Venda VincularUsuario(int idUsuario)
        {
            IdUsuario = idUsuario;
            return this;
        }

        public Venda AdicionarFormaPagamento(VendaFormaPagamento formaPagamento)
        {
            VendaFormaPagamento.Add(formaPagamento);
            return this;
        }

        #region Relacionamentos

        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<ItemVenda> ItemVendas { get; set; } = [];
        public ICollection<VendaFormaPagamento> VendaFormaPagamento { get; set; } = [];
        public ICollection<MovimentacaoEstoque> MovimentacaoEstoques { get; set; } = [];
        //public int IdCliente { get; set; }
        //public Cliente Cliente { get; set; }

        #endregion
    }
}
