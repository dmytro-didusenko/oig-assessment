using Infrastructure.Context;
using MediatR;
using DB = Infrastructure.Context.Entities;

namespace Application.Organization.Commands.Update
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, uint>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public UpdateOrganizationCommandHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<uint> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organizationToUpdate = new DB.Organization()
            {
                Id = request.Id,
                Name = request.Name,
                ParentId = request.ParentId
            };

            _organizationDbContext.Organizations.Update(organizationToUpdate);
            await _organizationDbContext.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
