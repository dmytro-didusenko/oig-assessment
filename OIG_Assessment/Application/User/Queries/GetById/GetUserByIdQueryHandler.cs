using Application.Extensions;
using Application.Organization.Dtos;
using Application.Role.Dtos;
using Application.User.Dtos;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Queries.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public GetUserByIdQueryHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user =  await _organizationDbContext.Users
                .AsNoTracking()
                .Include(o => o.Organization)
                .Where(u => u.Id == request.Id)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,

                    Organization = new OrganizationDto 
                    { 
                        Id = u.Organization.Id,
                        Name = u.Organization.Name,
                    },
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
                return null;

            var allOrganizations = await _organizationDbContext.Organizations
                .AsNoTracking()
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

            var childOrganizations = allOrganizations.GetOrganizationChildren(user.Organization.Id);

            user.Roles = childOrganizations.SelectMany(r => r.Roles).DistinctBy(r => r.Id).ToList();

            return user;
        }
    }
}
