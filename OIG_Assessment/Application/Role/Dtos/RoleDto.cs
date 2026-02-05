using Domain.Enums;

namespace Application.Role.Dtos
{
    public class RoleDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
    }
}
