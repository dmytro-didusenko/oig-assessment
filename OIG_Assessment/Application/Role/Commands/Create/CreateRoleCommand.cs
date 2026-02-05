using Domain.Enums;
using MediatR;

namespace Application.Role.Commands.Create
{
    public class CreateRoleCommand : IRequest<uint>
    {
        public string Name { get; set; }
        public uint OrganizationId { get; set; }
        public IEnumerable<Permission> RolePermissions { get; set; }
    }
}