namespace Application.Dtos.OrganizationTree
{
    public class OrganizationNode
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint? ParentId { get; set; }
        public List<OrganizationNode> Children { get; set; } = new List<OrganizationNode>();
    }
}
