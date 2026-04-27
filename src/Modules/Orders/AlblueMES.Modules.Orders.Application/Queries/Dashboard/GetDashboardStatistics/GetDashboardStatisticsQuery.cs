using AlblueMES.Modules.Orders.Application.DTOs.Dashboard;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetDashboardStatistics;

public record GetDashboardStatisticsQuery(Guid TenantId) : IRequest<DashboardStatisticsDto>;
