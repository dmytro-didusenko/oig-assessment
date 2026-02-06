using Application.Role.Dtos;

namespace Application.Organization.Dtos
{
    public class OrganizationDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint? ParentId { get; set; }  
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
