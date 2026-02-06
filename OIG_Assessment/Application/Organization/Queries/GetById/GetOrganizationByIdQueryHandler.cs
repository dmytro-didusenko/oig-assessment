using Application.Organization.Dtos;
using Application.Role.Dtos;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Organization.Queries.GetById
{
    public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, OrganizationDto?>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public GetOrganizationByIdQueryHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<OrganizationDto?> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _organizationDbContext.Organizations
                .Include(r => r.Roles)
                .Where(o => o.Id == request.Id)
                .Select(o => new OrganizationDto 
                {
                    Id = o.Id,
                    Name = o.Name,
                    Roles = o.Roles
                        .Select(role => new RoleDto 
                        { 
                            Id = role.Id,
                            Name = role.Name,
                            Permissions = role.RolePermissions
                                .Select(p => p.Permission)
                        })
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
