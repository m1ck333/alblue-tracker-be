using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;
using AlblueMES.Modules.Orders.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.Queries.GetChangeRequests;

public record GetChangeRequestsQuery : PagedQuery<PagedResult<ChangeRequestDto>>
{
    public Guid TenantId { get; init; }
    public RequestStatus? Status { get; init; }
    public ChangeRequestType? RequestType { get; init; }
    public Guid? OrderId { get; init; }
}
