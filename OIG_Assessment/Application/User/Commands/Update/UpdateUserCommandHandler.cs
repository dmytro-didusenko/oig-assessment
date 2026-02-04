using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DB = Infrastructure.Context.Entities;

namespace Application.User.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, uint>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public UpdateUserCommandHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<uint> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = new DB.User()
            {
                Id = request.Id,
                Name = request.Name,
                OrganizationId = request.OrganizationId
            };

            _organizationDbContext.Users.Update(userToUpdate);
            await _organizationDbContext.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
