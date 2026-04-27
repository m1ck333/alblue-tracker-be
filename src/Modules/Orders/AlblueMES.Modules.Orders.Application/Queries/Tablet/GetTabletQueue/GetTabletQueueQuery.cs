using AlblueMES.Modules.Orders.Application.DTOs.Tablet;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Tablet.GetTabletQueue;

public record GetTabletQueueQuery(Guid TenantId, Guid UserId) : IRequest<IReadOnlyList<ProcessGroupDto<TabletQueueItemDto>>>;
