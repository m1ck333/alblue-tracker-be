using AlblueMES.BuildingBlocks.Common.Interfaces;
using AlblueMES.Modules.Orders.Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace AlblueMES.API.Services;

public class ProcessChangeNotifier : IProcessChangeNotifier
{
    private readonly IHubContext<ProductionHub> _hubContext;

    public ProcessChangeNotifier(IHubContext<ProductionHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public Task NotifyProcessDefinitionChangedAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        return _hubContext.Clients.Group($"tenant-{tenantId}")
            .SendAsync("ProcessDefinitionUpdated", new { TenantId = tenantId }, cancellationToken);
    }
}
