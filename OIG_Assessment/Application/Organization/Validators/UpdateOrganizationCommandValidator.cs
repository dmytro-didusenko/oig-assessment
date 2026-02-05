using Application.Organization.Commands.Update;
using Application.User.Commands.Update;
using FluentValidation;

namespace Application.User.Validators
{
    public class UpdateUpdateUserCommandValidator : AbstractValidator<UpdateOrganizationCommand>
    {
        public UpdateUpdateUserCommandValidator()
        {
            RuleFor(u => u.Id).NotNull().GreaterThan(0u);
            RuleFor(u => u.Name).NotEmpty().MaximumLength(200);
            RuleFor(u => u.ParentId).NotNull().GreaterThan(0u);
        }
    }
}
