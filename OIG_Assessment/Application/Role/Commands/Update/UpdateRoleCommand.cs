using Domain.Enums;
using MediatR;

namespace Application.Role.Commands.Update
{
    public class UpdateRoleCommand : IRequest<uint>
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint OrganizationId { get; set; }
        public IEnumerable<Permission> RolePermissions { get; set; }
    }
}
