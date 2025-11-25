namespace Agropet.Domain.Entities
{
    public class Estoque : BaseEntity
    {
        public string Nome { get; set; } = null!;

        public ICollection<EstoqueProduto>? EstoqueLote { get; set; }
    }
}