using MediatR;

namespace Application.Organization.Commands.Update
{
    public class UpdateOrganizationCommand : IRequest<uint>
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint ParentId { get; set; }
    }
}
