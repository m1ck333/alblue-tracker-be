using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;
using AlblueMES.Modules.Orders.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.Queries.GetOrders;

public record GetOrdersQuery : PagedQuery<PagedResult<OrderDto>>
{
    public Guid TenantId { get; init; }
    public OrderStatus? Status { get; init; }
    public OrderType? OrderType { get; init; }
    public DateTime? DateFrom { get; init; }
    public DateTime? DateTo { get; init; }
}
