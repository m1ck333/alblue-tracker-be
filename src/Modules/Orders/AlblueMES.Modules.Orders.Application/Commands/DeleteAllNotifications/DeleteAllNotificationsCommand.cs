using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.DeleteAllNotifications;

public record DeleteAllNotificationsCommand(Guid UserId) : IRequest<Unit>;
