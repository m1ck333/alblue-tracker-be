using AlblueMES.Modules.Orders.Application.DTOs.Reports;
using AlblueMES.Modules.Production.Domain.Enums;

namespace AlblueMES.Modules.Orders.Application.Interfaces;

public interface IReportingQueryService
{
    Task<ProcessAveragesDto> GetProcessAveragesAsync(Guid tenantId, CancellationToken cancellationToken = default);

    Task<TimeTrackingReportDto> GetTimeTrackingReportAsync(
        Guid tenantId,
        DateTime? from,
        DateTime? to,
        Guid? processId,
        ComplexityType? complexity,
        CancellationToken cancellationToken = default);

    Task<WorkerHoursReportDto> GetWorkerHoursReportAsync(
        Guid tenantId,
        DateOnly from,
        DateOnly to,
        Guid? userId,
        CancellationToken cancellationToken = default);
}
