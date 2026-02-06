namespace Infrastructure.Context.Entities
{
    public class Organization : EntityBase
    {
        public string Name { get; set; }
        public uint? ParentId { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
