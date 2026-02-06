using Application.Organization.Dtos;
using Application.Role.Dtos;

namespace Application.User.Dtos
{
    public class UserDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public OrganizationDto Organization { get; set; }
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
