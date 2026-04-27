namespace AlblueMES.BuildingBlocks.Common.Interfaces;

public interface IProcessChangeNotifier
{
    Task NotifyProcessDefinitionChangedAsync(Guid tenantId, CancellationToken cancellationToken = default);
}
