namespace Agropet.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; private set; } = DateTime.Now;
    }
}
