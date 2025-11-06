using System.ComponentModel.DataAnnotations.Schema;

namespace Agropet.Domain.Entities
{
    public class Estoque : EntityBase
    {
        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}