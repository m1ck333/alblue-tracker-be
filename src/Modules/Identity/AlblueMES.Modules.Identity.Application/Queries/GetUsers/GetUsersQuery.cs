using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Identity.Application.DTOs;
using AlblueMES.Modules.Identity.Domain.Entities;

namespace AlblueMES.Modules.Identity.Application.Queries.GetUsers;

public record GetUsersQuery : PagedQuery<PagedResult<UserDto>>
{
    public Guid TenantId { get; init; }
    public UserRole? Role { get; init; }
    public bool? IsActive { get; init; }
}
