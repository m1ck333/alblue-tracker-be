using AlblueMES.Modules.Orders.Application.Commands.CreateBlockRequest;
using FluentValidation;

namespace AlblueMES.Modules.Orders.Application.Validators;

public class CreateBlockRequestCommandValidator : AbstractValidator<CreateBlockRequestCommand>
{
    public CreateBlockRequestCommandValidator()
    {
        RuleFor(x => x.TenantId).NotEmpty();
        RuleFor(x => x.RequestedByUserId).NotEmpty();
        RuleFor(x => x)
            .Must(x => x.OrderItemProcessId.HasValue || x.OrderItemSubProcessId.HasValue)
            .WithMessage("Either OrderItemProcessId or OrderItemSubProcessId must be provided.");
    }
}
