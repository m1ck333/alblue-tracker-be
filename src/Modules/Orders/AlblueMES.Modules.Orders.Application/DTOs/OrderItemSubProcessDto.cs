using AlblueMES.Modules.Orders.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.DTOs;

public record OrderItemSubProcessDto(
    Guid Id,
    Guid OrderItemProcessId,
    Guid SubProcessId,
    SubProcessStatus Status,
    int TotalDurationMinutes,
    bool IsWithdrawn,
    bool IsTimerRunning,
    DateTime? CurrentLogStartedAt);
