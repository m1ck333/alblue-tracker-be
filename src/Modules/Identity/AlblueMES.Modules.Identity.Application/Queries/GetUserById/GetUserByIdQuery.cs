using AlblueMES.Modules.Identity.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Identity.Application.Queries.GetUserById;

public record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;
