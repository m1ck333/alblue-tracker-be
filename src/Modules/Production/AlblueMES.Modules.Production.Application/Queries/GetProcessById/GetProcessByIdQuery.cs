using AlblueMES.Modules.Production.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Queries.GetProcessById;

public record GetProcessByIdQuery(Guid Id) : IRequest<ProcessDto>;
