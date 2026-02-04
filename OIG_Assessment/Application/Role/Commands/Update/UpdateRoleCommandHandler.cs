using Infrastructure.Context;
using MediatR;

namespace Application.Role.Commands.Update
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, uint>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public UpdateRoleCommandHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public Task<uint> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
