using AlblueMES.Modules.Orders.Application.DTOs.Dashboard;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetDeadlineWarnings;

public record GetDeadlineWarningsQuery(Guid TenantId) : IRequest<IReadOnlyList<DeadlineWarningDto>>;
