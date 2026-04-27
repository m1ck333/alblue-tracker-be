using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;

namespace AlblueMES.Modules.Orders.Application.Queries.GetNotifications;

public record GetNotificationsQuery : PagedQuery<PagedResult<NotificationDto>>
{
    public Guid UserId { get; init; }
    public bool? IsRead { get; init; }
}
