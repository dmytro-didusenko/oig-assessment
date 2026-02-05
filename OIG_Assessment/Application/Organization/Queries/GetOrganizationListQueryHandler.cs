using Application.Organization.Dtos;
using Application.Role.Dtos;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Organization.Queries
{
    public class GetOrganizationListQueryHandler : IRequestHandler<GetOrganizationListQuery, IEnumerable<OrganizationDto>>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public GetOrganizationListQueryHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<IEnumerable<OrganizationDto>> Handle(GetOrganizationListQuery request, CancellationToken cancellationToken)
        {
            return await _organizationDbContext.Organizations
                .Include(r => r.Roles)
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
                .ToListAsync(cancellationToken);
        }
    }
}
