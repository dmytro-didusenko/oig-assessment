using MediatR;

namespace Application.Organization.Commands.Create
{
    public class CreateOrganizationCommand : IRequest<uint>
    {
        public string Name { get; set; }
        public uint ParentId { get; set; }
    }
}
