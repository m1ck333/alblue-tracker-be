namespace AlblueMES.Modules.Orders.Api.Requests;

public record StationRequest(Guid ProcessId, Guid TenantId, Guid UserId);
