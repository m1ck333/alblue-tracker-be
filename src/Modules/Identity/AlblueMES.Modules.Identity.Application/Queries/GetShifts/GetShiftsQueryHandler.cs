using AlblueMES.BuildingBlocks.Common.Pagination;
using AlblueMES.Modules.Identity.Application.DTOs;
using AlblueMES.Modules.Identity.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Queries.GetShifts;

public class GetShiftsQueryHandler : IRequestHandler<GetShiftsQuery, PagedResult<ShiftDto>>
{
    private readonly IShiftRepository _shiftRepository;

    public GetShiftsQueryHandler(IShiftRepository shiftRepository)
    {
        _shiftRepository = shiftRepository;
    }

    public async Task<PagedResult<ShiftDto>> Handle(GetShiftsQuery request, CancellationToken cancellationToken)
    {
        var result = await _shiftRepository.GetPagedAsync(
            request.TenantId, request.IsActive, request.Search,
            request.GetCreatedFromUtc(), request.GetCreatedToUtc(),
            request.SortBy, request.IsDescending,
            request.GetPage(), request.GetPageSize(), cancellationToken);

        return result.MapItems(s => s.Adapt<ShiftDto>());
    }
}
