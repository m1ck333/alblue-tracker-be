using AlblueMES.Modules.Identity.Application.Commands.CreateUser;
using AlblueMES.Modules.Identity.Domain.Entities;
using FluentValidation;

namespace AlblueMES.Modules.Identity.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.TenantId).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(100);
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Role).IsInEnum();
        RuleFor(x => x.ProcessIds).NotEmpty().When(x => x.Role == UserRole.Department);
    }
}
