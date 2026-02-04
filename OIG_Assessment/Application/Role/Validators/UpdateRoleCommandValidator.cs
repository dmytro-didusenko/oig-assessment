using Application.Role.Commands.Update;
using FluentValidation;

namespace Application.Role.Validators
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(u => u.Id).NotNull().GreaterThan(0u);
            RuleFor(u => u.Name).NotEmpty().MaximumLength(200);
            RuleFor(u => u.OrganizationId).NotNull().GreaterThan(0u);
            RuleFor(u => u.RolePermissions).NotNull().NotEmpty().WithMessage("Role permission list shouldn't be empty");
        }
    }
}
