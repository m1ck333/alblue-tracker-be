using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.MarkNotificationUnread;

public record MarkNotificationUnreadCommand(Guid Id) : IRequest<Unit>;
