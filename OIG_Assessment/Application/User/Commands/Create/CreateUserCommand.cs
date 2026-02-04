using MediatR;

namespace Application.User.Commands.Create
{
    public class CreateUserCommand : IRequest<uint>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public uint OrganizationId { get; set; }
    }
}
