using AlblueMES.Modules.Tenancy.Application.Commands.UpdateTenant;
using FluentValidation;

namespace AlblueMES.Modules.Tenancy.Application.Validators;

public class UpdateTenantCommandValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdateTenantCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
