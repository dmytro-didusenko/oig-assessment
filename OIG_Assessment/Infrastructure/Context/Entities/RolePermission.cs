using Domain.Enums;

namespace Infrastructure.Context.Entities
{
    public class RolePermission
    {
        public uint RoleId { get; set; }
        public Permission Permission { get; set; }

        public Role Role { get; set; }
    }
}