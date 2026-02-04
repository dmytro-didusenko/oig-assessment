using Application.User.Commands.Create;
using FluentValidation;

namespace Application.User.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(u => u.Name).NotEmpty().MaximumLength(200);
            RuleFor(u => u.Email).NotEmpty().EmailAddress().MaximumLength(200);
            RuleFor(u => u.OrganizationId).NotNull().GreaterThan(0u);
        }
    }
}
