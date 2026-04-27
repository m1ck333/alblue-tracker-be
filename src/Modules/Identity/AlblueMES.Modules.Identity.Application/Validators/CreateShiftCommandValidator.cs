using AlblueMES.Modules.Identity.Application.Commands.CreateShift;
using FluentValidation;

namespace AlblueMES.Modules.Identity.Application.Validators;

public class CreateShiftCommandValidator : AbstractValidator<CreateShiftCommand>
{
    public CreateShiftCommandValidator()
    {
        RuleFor(x => x.TenantId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
