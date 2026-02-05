using Infrastructure.Context;
using MediatR;
using DB = Infrastructure.Context.Entities;

namespace Application.Role.Commands.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, uint>
    {
        private readonly OrganizationDbContext _organizationDbContext;

        public CreateRoleCommandHandler(OrganizationDbContext organizationDbContext)
        {
            _organizationDbContext = organizationDbContext;
        }

        public async Task<uint> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await _organizationDbContext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var roleToAdd = new DB.Role()
                {
                    Name = request.Name,
                    OrganizationId = request.OrganizationId,
                };

                var result = await _organizationDbContext.Roles.AddAsync(roleToAdd, cancellationToken);
                await _organizationDbContext.SaveChangesAsync(cancellationToken);

                var rolePermissions = request.RolePermissions
                    .Select(permission => new DB.RolePermission
                    {
                        RoleId = result.Entity.Id,
                        Permission = permission
                    });

                await _organizationDbContext.RolePermissions.AddRangeAsync(rolePermissions, cancellationToken);
                await _organizationDbContext.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return result.Entity.Id;
            }
            catch (Exception ex) 
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}
