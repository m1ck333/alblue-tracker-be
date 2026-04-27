namespace AlblueMES.Modules.Orders.Api.Requests;

public record HandleBlockRequestRequest(Guid HandledByUserId, string? Note);
