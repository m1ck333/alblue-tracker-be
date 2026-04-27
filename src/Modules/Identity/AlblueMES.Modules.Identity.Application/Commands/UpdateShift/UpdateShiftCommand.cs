using AlblueMES.Modules.Identity.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.UpdateShift;

public record UpdateShiftCommand(
    Guid Id,
    string Name,
    TimeOnly StartTime,
    TimeOnly EndTime,
    bool IsActive) : IRequest<ShiftDto>;
