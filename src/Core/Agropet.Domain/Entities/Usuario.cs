namespace Agropet.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public string Senha { get; set; } = null!;

        #region Relacionamento
        //public ICollection<Cliente>? Clientes { get; set; }
        //public ICollection<Produto>? Produtos { get; set; }
        //public ICollection<Venda>? Vendas { get; set; }
        #endregion
    }
}
