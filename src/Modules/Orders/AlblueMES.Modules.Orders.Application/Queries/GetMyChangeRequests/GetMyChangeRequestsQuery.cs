using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;
using AlblueMES.Modules.Orders.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.Queries.GetMyChangeRequests;

public record GetMyChangeRequestsQuery : PagedQuery<PagedResult<ChangeRequestDto>>
{
    public Guid TenantId { get; init; }
    public Guid UserId { get; init; }
    public RequestStatus? Status { get; init; }
}
