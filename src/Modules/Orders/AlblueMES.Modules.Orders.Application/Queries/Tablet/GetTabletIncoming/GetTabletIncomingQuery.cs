using AlblueMES.Modules.Orders.Application.DTOs.Tablet;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Tablet.GetTabletIncoming;

public record GetTabletIncomingQuery(Guid TenantId, Guid UserId) : IRequest<IReadOnlyList<ProcessGroupDto<TabletIncomingDto>>>;
