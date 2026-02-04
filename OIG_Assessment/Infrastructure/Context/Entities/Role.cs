using Domain.Enums;

namespace Infrastructure.Context.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public uint OrganizationId { get; set; }

        public IEnumerable<Permission> RolePermissions { get; set; }
    }
}
