using Domain.Enums;

namespace Domain.Dtos
{
    public class UpdateRoleDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint OrganizationId { get; set; }
        public IEnumerable<Permission> RolePermissions { get; set; }
    }
}
