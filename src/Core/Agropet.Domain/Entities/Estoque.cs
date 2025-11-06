using System.ComponentModel.DataAnnotations.Schema;

namespace Agropet.Domain.Entities
{
    public class Estoque : BaseEntity
    {
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public Produto? Produto { get; set; }
    }
}