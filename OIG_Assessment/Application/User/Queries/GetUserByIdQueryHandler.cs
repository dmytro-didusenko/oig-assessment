using Application.Organization.Dtos;
using Application.Role.Dtos;
using Application.User.Dtos;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Queries
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
            return await _organizationDbContext.Users
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

                    Roles = u.Organization.Roles.Select(r => new RoleDto 
                    { 
                        Id = r.Id,
                        Name = r.Name,
                        Permissions = r.RolePermissions.Select(rp => rp.Permission)
                    })
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
