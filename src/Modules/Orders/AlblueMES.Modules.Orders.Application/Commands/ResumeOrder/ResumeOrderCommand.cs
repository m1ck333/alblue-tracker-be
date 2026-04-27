using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.ResumeOrder;

public record ResumeOrderCommand(Guid Id) : IRequest<Unit>;
