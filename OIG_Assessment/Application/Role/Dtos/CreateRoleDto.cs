using Domain.Enums;

namespace Domain.Dtos
{
    public class CreateRoleDto
    {
        public string Name { get; set; }
        public uint OrganizationId { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
    }
}
