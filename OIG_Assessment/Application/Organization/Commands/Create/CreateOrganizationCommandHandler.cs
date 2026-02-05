using Infrastructure.Context;
using MediatR;
using DB = Infrastructure.Context.Entities;

namespace Application.Organization.Commands.Create
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, uint>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public CreateOrganizationCommandHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<uint> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organizationToAdd = new DB.Organization 
            { 
                Name = request.Name,
                ParentId = request.ParentId
            };

            var result = await _organizationDbContext.AddAsync(organizationToAdd, cancellationToken);
            await _organizationDbContext.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
    }
}
