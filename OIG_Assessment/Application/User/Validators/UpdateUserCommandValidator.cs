using Application.User.Commands.Update;
using FluentValidation;

namespace Application.User.Validators
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(u => u.Id).NotNull().GreaterThan(0u);
            RuleFor(u => u.Name).NotEmpty().MaximumLength(200);
            RuleFor(u => u.OrganizationId).NotNull().GreaterThan(0u);
        }
    }
}
