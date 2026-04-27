using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;

namespace AlblueMES.Modules.Orders.Application.Queries.GetWorkSessions;

public record GetWorkSessionsQuery : PagedQuery<PagedResult<WorkSessionDto>>
{
    public Guid TenantId { get; init; }
    public DateOnly Date { get; init; }
    public Guid? UserId { get; init; }
}
