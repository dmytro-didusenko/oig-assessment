namespace Infrastructure.Context.Entities
{
    public class EntityBase
    {
        public uint Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public uint CreatedBy { get; set; }
    }
}
