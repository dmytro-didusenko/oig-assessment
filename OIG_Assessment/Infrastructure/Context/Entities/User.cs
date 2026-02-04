namespace Infrastructure.Context.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public uint OrganizationId { get; set; }

        public Organization UserOrganization { get; set; }
    }
}
