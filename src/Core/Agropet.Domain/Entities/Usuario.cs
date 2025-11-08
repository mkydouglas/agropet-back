using Microsoft.AspNetCore.Identity;

namespace Agropet.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; } = null!;
        public string CPF { get; private set; } = null!;
        public string SenhaHash { get; private set; } = null!;

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

        public void DefinirSenha(string senhaPura, IPasswordHasher<Usuario> hasher)
        {
            SenhaHash = hasher.HashPassword(this, senhaPura);
        }

        public bool VerificarSenha(string senhaPura, IPasswordHasher<Usuario> hasher)
        {
            var result = hasher.VerifyHashedPassword(this, SenhaHash, senhaPura);
            return result == PasswordVerificationResult.Success;
        }

        #region Relacionamento
        //public ICollection<Cliente>? Clientes { get; set; }
        //public ICollection<Produto>? Produtos { get; set; }
        //public ICollection<Venda>? Vendas { get; set; }
        #endregion
    }
}
