using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.DeleteNotification;

public record DeleteNotificationCommand(Guid Id) : IRequest<Unit>;
