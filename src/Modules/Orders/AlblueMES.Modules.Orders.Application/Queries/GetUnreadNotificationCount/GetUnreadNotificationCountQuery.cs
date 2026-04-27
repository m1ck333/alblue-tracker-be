using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.GetUnreadNotificationCount;

public record GetUnreadNotificationCountQuery(Guid UserId) : IRequest<int>;
