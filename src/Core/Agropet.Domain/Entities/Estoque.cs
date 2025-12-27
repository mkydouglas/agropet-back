namespace Agropet.Domain.Entities
{
    public class Estoque : BaseEntity
    {
        public string Nome { get; set; } = null!;

        public ICollection<EstoqueProduto>? EstoqueProduto { get; set; }
    }
}