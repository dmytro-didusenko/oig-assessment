using MediatR;

namespace Application.User.Commands.Update
{
    public class UpdateUserCommand : IRequest<uint>
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint OrganizationId { get; set; }
    }
}
