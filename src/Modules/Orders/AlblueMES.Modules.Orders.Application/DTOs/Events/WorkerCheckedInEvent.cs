namespace AlblueMES.Modules.Orders.Application.DTOs.Events;

public record WorkerCheckedInEvent(
    Guid UserId,
    Guid SessionId,
    Guid TenantId);
