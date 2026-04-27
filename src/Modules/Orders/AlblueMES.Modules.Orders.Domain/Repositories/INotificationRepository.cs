using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Domain.Entities;

namespace AlblueMES.Modules.Orders.Domain.Repositories;

public interface INotificationRepository
{
    Task<Notification?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Notification>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<int> GetUnreadCountAsync(Guid userId, CancellationToken cancellationToken = default);
    Task AddAsync(Notification notification, CancellationToken cancellationToken = default);
    void Delete(Notification notification);
    Task DeleteAllByUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task MarkAllReadAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<PagedResult<Notification>> GetPagedAsync(Guid userId, bool? isRead, string? search, int page, int pageSize, CancellationToken cancellationToken = default);
}
