namespace Agropet.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; } = null!;
        public string CPF { get; private set; } = null!;
        public string Senha { get; private set; } = null!;

        public Usuario AtualizarNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public Usuario AtualizarCPF(string cpf)
        {
            CPF = cpf;
            return this;
        }

        #region Relacionamento
        //public ICollection<Cliente>? Clientes { get; set; }
        //public ICollection<Produto>? Produtos { get; set; }
        //public ICollection<Venda>? Vendas { get; set; }
        #endregion
    }
}
