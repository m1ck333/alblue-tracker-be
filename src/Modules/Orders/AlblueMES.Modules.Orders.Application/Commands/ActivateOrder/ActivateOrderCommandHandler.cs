using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Orders.Application.DTOs.Events;
using AlblueMES.Modules.Orders.Application.Interfaces;
using AlblueMES.Modules.Orders.Domain.Enums;
using AlblueMES.Modules.Orders.Domain.Repositories;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.ActivateOrder;

public class ActivateOrderCommandHandler : IRequestHandler<ActivateOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrdersUnitOfWork _unitOfWork;
    private readonly IProductionEventService _eventService;

    public ActivateOrderCommandHandler(IOrderRepository orderRepository, IOrdersUnitOfWork unitOfWork, IProductionEventService eventService)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _eventService = eventService;
    }

    public async Task<Unit> Handle(ActivateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdWithFullDetailsAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Order", request.Id);

        // Handle previously started processes (reactivation after cancel)
        var resetIds = request.ResetProcessIds ?? new List<Guid>();
        foreach (var item in order.Items)
        {
            foreach (var proc in item.Processes)
            {
                if (resetIds.Contains(proc.Id))
                {
                    proc.ResetTimer();
                }
                else if (proc.Status == ProcessStatus.InProgress)
                {
                    // Return paused/running processes to Pending - worker starts manually
                    proc.ReturnToPending();
                }
            }
        }

        order.Activate();
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _eventService.NotifyOrderActivatedAsync(
            new OrderActivatedEvent(order.Id, order.OrderNumber, order.TenantId), cancellationToken);

        return Unit.Value;
    }
}
