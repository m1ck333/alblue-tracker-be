using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;
using AlblueMES.Modules.Orders.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.Queries.GetOrdersMasterView;

public record GetOrdersMasterViewQuery : PagedQuery<PagedResult<OrderMasterViewDto>>
{
    public Guid TenantId { get; init; }
    public OrderStatus? Status { get; init; }
    public OrderType? OrderType { get; init; }
    public DateTime? DateFrom { get; init; }
    public DateTime? DateTo { get; init; }
}
