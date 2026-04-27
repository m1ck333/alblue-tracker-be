using AlblueMES.Modules.Orders.Application.Commands.CreateChangeRequest;
using FluentValidation;

namespace AlblueMES.Modules.Orders.Application.Validators;

public class CreateChangeRequestCommandValidator : AbstractValidator<CreateChangeRequestCommand>
{
    public CreateChangeRequestCommandValidator()
    {
        RuleFor(x => x.TenantId).NotEmpty();
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.RequestedByUserId).NotEmpty();
        RuleFor(x => x.RequestType).IsInEnum();
        RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
    }
}
