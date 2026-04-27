using AlblueMES.Modules.Identity.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Commands.CreateShift;

public record CreateShiftCommand(
    Guid TenantId,
    string Name,
    TimeOnly StartTime,
    TimeOnly EndTime) : IRequest<ShiftDto>;
