using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.MarkAllNotificationsRead;

public record MarkAllNotificationsReadCommand(Guid UserId) : IRequest<Unit>;
