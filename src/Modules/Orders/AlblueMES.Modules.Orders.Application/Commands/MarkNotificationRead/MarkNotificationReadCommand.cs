using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.MarkNotificationRead;

public record MarkNotificationReadCommand(Guid Id) : IRequest<Unit>;
