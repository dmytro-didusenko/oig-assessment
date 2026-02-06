namespace Application.Dtos.OrganizationTree
{
    public class Organization
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint? ParentId { get; set; }
    }
}
