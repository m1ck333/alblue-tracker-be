using AlblueMES.Modules.Production.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Queries.GetProductCategoryById;

public record GetProductCategoryByIdQuery(Guid Id) : IRequest<ProductCategoryDetailDto>;
