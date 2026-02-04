namespace Domain.Dtos
{
    public class UpdateUserDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint OrganizationId { get; set; }
    }
}
