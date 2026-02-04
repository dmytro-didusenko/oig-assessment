namespace Infrastructure.Context.Entities
{
    public class Organization : EntityBase
    {
        public string Name { get; set; }
        public uint? ParentId { get; set; }


        public IEnumerable<User> OrganizationUsers { get; set; }
        public IEnumerable<Role> OrganizationRoles { get; set; }
    }
}
