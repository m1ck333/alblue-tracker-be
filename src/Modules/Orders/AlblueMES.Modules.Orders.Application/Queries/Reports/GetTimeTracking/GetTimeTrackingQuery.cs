using AlblueMES.Modules.Orders.Application.DTOs.Reports;
using AlblueMES.Modules.Production.Domain.Enums;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Reports.GetTimeTracking;

public record GetTimeTrackingQuery(
    Guid TenantId,
    DateTime? From,
    DateTime? To,
    Guid? ProcessId,
    ComplexityType? Complexity) : IRequest<TimeTrackingReportDto>;
