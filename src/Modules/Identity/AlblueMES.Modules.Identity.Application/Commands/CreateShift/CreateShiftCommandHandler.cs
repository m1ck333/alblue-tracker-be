using AlblueMES.Modules.Identity.Application.DTOs;
using AlblueMES.Modules.Identity.Application.Interfaces;
using AlblueMES.Modules.Identity.Domain.Entities;
using AlblueMES.Modules.Identity.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.CreateShift;

public class CreateShiftCommandHandler : IRequestHandler<CreateShiftCommand, ShiftDto>
{
    private readonly IShiftRepository _shiftRepository;
    private readonly IIdentityUnitOfWork _unitOfWork;

    public CreateShiftCommandHandler(IShiftRepository shiftRepository, IIdentityUnitOfWork unitOfWork)
    {
        _shiftRepository = shiftRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ShiftDto> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
    {
        var shift = Shift.Create(
            request.TenantId,
            request.Name,
            request.StartTime,
            request.EndTime);

        await _shiftRepository.AddAsync(shift, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return shift.Adapt<ShiftDto>();
    }
}
