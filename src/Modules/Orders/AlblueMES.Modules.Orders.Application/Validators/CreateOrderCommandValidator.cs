using AlblueMES.Modules.Orders.Application.Commands.CreateOrder;
using FluentValidation;

namespace AlblueMES.Modules.Orders.Application.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.TenantId).NotEmpty();
        RuleFor(x => x.OrderNumber).NotEmpty().MaximumLength(100);
        RuleFor(x => x.DeliveryDate).GreaterThan(DateTime.UtcNow.Date);
        RuleFor(x => x.Priority).GreaterThan(0);
        RuleFor(x => x.OrderType).IsInEnum();
        RuleFor(x => x.CreatedByUserId).NotEmpty();
    }
}
