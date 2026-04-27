namespace AlblueMES.Modules.Orders.Api.Requests;

public record HandleChangeRequestRequest(Guid HandledByUserId, string? ResponseNote);
