using Application.Organization.Commands.Create;
using FluentValidation;

namespace Application.User.Validators
{
    public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().MaximumLength(200);
            RuleFor(u => u.ParentId).NotNull().GreaterThan(0u);
        }
    }
}
