using AlblueMES.Modules.Orders.Application.DTOs.Reports;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Reports.GetWorkerHours;

public record GetWorkerHoursQuery(
    Guid TenantId,
    DateOnly From,
    DateOnly To,
    Guid? UserId) : IRequest<WorkerHoursReportDto>;
