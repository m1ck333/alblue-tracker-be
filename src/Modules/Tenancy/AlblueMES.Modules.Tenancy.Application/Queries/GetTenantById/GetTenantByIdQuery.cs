using AlblueMES.Modules.Tenancy.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Tenancy.Application.Queries.GetTenantById;

public record GetTenantByIdQuery(Guid Id) : IRequest<TenantDto>;
