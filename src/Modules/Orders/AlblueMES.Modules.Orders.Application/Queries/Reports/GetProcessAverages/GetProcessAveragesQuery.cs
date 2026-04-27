using AlblueMES.Modules.Orders.Application.DTOs.Reports;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Reports.GetProcessAverages;

public record GetProcessAveragesQuery(Guid TenantId) : IRequest<ProcessAveragesDto>;
