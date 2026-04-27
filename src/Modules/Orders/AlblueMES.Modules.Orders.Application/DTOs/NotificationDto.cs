using AlblueMES.Modules.Orders.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.DTOs;

public record NotificationDto(
    Guid Id,
    Guid UserId,
    NotificationType Type,
    string Title,
    string Message,
    string? ReferenceType,
    Guid? ReferenceId,
    bool IsRead,
    DateTime CreatedAt);
