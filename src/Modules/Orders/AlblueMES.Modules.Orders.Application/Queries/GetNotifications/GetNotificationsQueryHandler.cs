using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;
using AlblueMES.Modules.Orders.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.GetNotifications;

public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, PagedResult<NotificationDto>>
{
    private readonly INotificationRepository _notificationRepository;

    public GetNotificationsQueryHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<PagedResult<NotificationDto>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
    {
        var result = await _notificationRepository.GetPagedAsync(
            request.UserId, request.IsRead, request.Search,
            request.GetPage(), request.GetPageSize(), cancellationToken);

        return result.MapItems(n => n.Adapt<NotificationDto>());
    }
}
