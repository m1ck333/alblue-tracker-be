using AlblueMES.Modules.Orders.Domain.Enums;
using AlblueMES.Modules.Production.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.DTOs;

public record OrderItemProcessDto(
    Guid Id,
    Guid OrderItemId,
    Guid ProcessId,
    ComplexityType? Complexity,
    bool ComplexityOverridden,
    ProcessStatus Status,
    DateTime? StartedAt,
    DateTime? CompletedAt,
    int TotalDurationMinutes,
    DateTime? PausedAt,
    DateTime? ResumedAt,
    bool IsWithdrawn,
    List<OrderItemSubProcessDto> SubProcesses);
