using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Orders.Application.DTOs;
using AlblueMES.Modules.Orders.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.GetChangeRequests;

public class GetChangeRequestsQueryHandler : IRequestHandler<GetChangeRequestsQuery, PagedResult<ChangeRequestDto>>
{
    private readonly IChangeRequestRepository _changeRequestRepository;

    public GetChangeRequestsQueryHandler(IChangeRequestRepository changeRequestRepository)
    {
        _changeRequestRepository = changeRequestRepository;
    }

    public async Task<PagedResult<ChangeRequestDto>> Handle(GetChangeRequestsQuery request, CancellationToken cancellationToken)
    {
        var result = await _changeRequestRepository.GetPagedAsync(
            request.TenantId, request.Status, request.RequestType, request.OrderId, request.Search,
            request.GetCreatedFromUtc(), request.GetCreatedToUtc(),
            request.SortBy, request.IsDescending,
            request.GetPage(), request.GetPageSize(), cancellationToken);

        return result.MapItems(c =>
        {
            var dto = c.Adapt<ChangeRequestDto>();
            return dto with { OrderNumber = c.Order?.OrderNumber };
        });
    }
}
