using Application.Role.Commands.Create;
using FluentValidation;

namespace Application.Role.Validators
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().MaximumLength(200);
            RuleFor(u => u.OrganizationId).NotNull().GreaterThan(0u);
            RuleFor(u => u.RolePermissions).NotNull().NotEmpty().WithMessage("Role permission list shouldn't be empty");
        }
    }
}
