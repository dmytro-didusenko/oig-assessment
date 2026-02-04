namespace Domain.Dtos
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public uint OrganizationId { get; set; }
    }
}
