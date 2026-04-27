using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;
using AlblueMES.Modules.Orders.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.Queries.GetBlockRequests;

public record GetBlockRequestsQuery : PagedQuery<PagedResult<BlockRequestDto>>
{
    public Guid TenantId { get; init; }
    public RequestStatus? Status { get; init; }
    public Guid? OrderId { get; init; }
}
