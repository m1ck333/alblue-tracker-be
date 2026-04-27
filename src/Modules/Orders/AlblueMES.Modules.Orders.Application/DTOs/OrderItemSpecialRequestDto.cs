namespace AlblueMES.Modules.Orders.Application.DTOs;

public record OrderItemSpecialRequestDto(
    Guid Id,
    Guid SpecialRequestTypeId);
