using System.ComponentModel.DataAnnotations.Schema;

namespace Agropet.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public Cliente(string nome, string cPF, int idUsuario)
        {
            Nome = nome;
            CPF = cPF;
            IdUsuario = idUsuario;
        }

        public Cliente(int id,string nome, string cPF, int idUsuario)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            IdUsuario = idUsuario;
        }

        public string Nome { get; set; } = null!;
        public string CPF { get; set; } = null!;

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public ICollection<Venda> Vendas { get; set; } = null!;
    }
}
