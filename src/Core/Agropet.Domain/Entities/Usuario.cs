using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Agropet.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; } = null!;
        public string CPF { get; private set; } = null!;
        public string SenhaHash { get; private set; } = null!;

        public Usuario AtualizarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return this;

            Nome = nome;
            return this;
        }

        public Usuario AtualizarCPF(string cpf)
        {
            if(string.IsNullOrWhiteSpace(cpf))
                return this;
            if(!Regex.IsMatch(cpf, @"^\d{11}$"))
                return this;

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
        public ICollection<Produto>? Produtos { get; set; }
        public ICollection<Compra>? Compras { get; set; }
        public ICollection<Fornecedor>? Fornecedores { get; set; }
        //public ICollection<Cliente>? Clientes { get; set; }
        //public ICollection<Venda>? Vendas { get; set; }
        #endregion
    }
}
