namespace Application.Organization.Dtos
{
    public class CreateOrganizationDto
    {
        public string Name { get; set; }
        public uint ParentId { get; set; }
    }
}
