using AlblueMES.Modules.Orders.Domain.Enums;

namespace AlblueMES.Modules.Orders.Api.Requests;

public record CreateChangeRequestRequest(
    Guid TenantId,
    Guid OrderId,
    Guid RequestedByUserId,
    ChangeRequestType RequestType,
    string Description);
