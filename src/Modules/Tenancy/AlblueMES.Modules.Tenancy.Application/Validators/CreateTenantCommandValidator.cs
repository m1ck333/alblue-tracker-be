using AlblueMES.Modules.Tenancy.Application.Commands.CreateTenant;
using FluentValidation;

namespace AlblueMES.Modules.Tenancy.Application.Validators;

public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
    }
}
