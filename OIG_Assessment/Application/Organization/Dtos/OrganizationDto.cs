using Application.Role.Dtos;

namespace Application.Organization.Dtos
{
    public class OrganizationDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        // TODO Implement (parent/child) hierarchical structure  
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
