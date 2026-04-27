using AlblueMES.BuildingBlocks.Common.Entities;
using AlblueMES.BuildingBlocks.Common.Exceptions;

namespace AlblueMES.Modules.Orders.Domain.Entities;

public class OrderItemSubProcessLog : TenantEntity
{
    public Guid OrderItemSubProcessId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }
    public int? DurationMinutes { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public OrderItemSubProcess OrderItemSubProcess { get; private set; } = null!;

    private OrderItemSubProcessLog()
    {
    }

    public static OrderItemSubProcessLog Start(Guid tenantId, Guid orderItemSubProcessId, Guid userId)
    {
        return new OrderItemSubProcessLog
        {
            TenantId = tenantId,
            OrderItemSubProcessId = orderItemSubProcessId,
            UserId = userId,
            StartTime = DateTime.UtcNow
        };
    }

    public void End()
    {
        if (EndTime.HasValue)
            throw new DomainException("ALREADY_ENDED", "Log already ended.");
        EndTime = DateTime.UtcNow;
        DurationMinutes = (int)(EndTime.Value - StartTime).TotalSeconds;
    }
}
