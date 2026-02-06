using Application.Organization.Dtos;
using Application.User.Dtos;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Queries.GetList
{
    public class UsersListQueryHandler : IRequestHandler<UsersListQuery, IEnumerable<UserDto>>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public UsersListQueryHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<IEnumerable<UserDto>> Handle(UsersListQuery request, CancellationToken cancellationToken)
        {
            return await _organizationDbContext.Users
                .AsNoTracking()
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,

                    Organization = new OrganizationDto
                    {
                        Id = u.Organization.Id,
                        Name = u.Organization.Name,
                    }
                })
                .ToListAsync(cancellationToken);
        }
    }
}
