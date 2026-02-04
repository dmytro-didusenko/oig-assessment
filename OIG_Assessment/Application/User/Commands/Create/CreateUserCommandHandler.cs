using Infrastructure.Context;
using MediatR;
using DB = Infrastructure.Context.Entities;

namespace Application.User.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, uint>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public CreateUserCommandHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<uint> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userToAdd = new DB.User()
            {
                Name = request.Name,
                Email = request.Email,
                OrganizationId = request.OrganizationId
            };

            var result = await _organizationDbContext.Users.AddAsync(userToAdd, cancellationToken);
            await _organizationDbContext.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
    }
}
