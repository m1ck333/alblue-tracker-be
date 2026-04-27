using AlblueMES.Modules.Orders.Application.DTOs.Dashboard;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetLiveView;

public record GetLiveViewQuery(Guid TenantId) : IRequest<IReadOnlyList<LiveViewProcessDto>>;
