namespace Application.Organization.Dtos
{
    public class UpdateOrganizationDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint ParentId { get; set; }
    }
}
