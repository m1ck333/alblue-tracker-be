using AlblueMES.BuildingBlocks.Common.Exceptions;
using AlblueMES.Modules.Production.Application.DTOs;
using AlblueMES.Modules.Production.Application.Interfaces;
using AlblueMES.Modules.Production.Domain.Repositories;
using Mapster;
using MediatR;

namespace AlblueMES.Modules.Production.Application.Commands.AddCategoryProcess;

public class AddCategoryProcessCommandHandler : IRequestHandler<AddCategoryProcessCommand, ProductCategoryDetailDto>
{
    private readonly IProductCategoryRepository _categoryRepository;
    private readonly IProductionUnitOfWork _unitOfWork;

    public AddCategoryProcessCommandHandler(IProductCategoryRepository categoryRepository, IProductionUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductCategoryDetailDto> Handle(AddCategoryProcessCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdWithDetailsAsync(request.CategoryId, cancellationToken)
            ?? throw new NotFoundException("ProductCategory", request.CategoryId);

        category.AddProcess(request.ProcessId, request.SequenceOrder, request.DefaultComplexity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Clear change tracker to force fresh load with all navigation properties
        _unitOfWork.ClearChangeTracker();

        category = await _categoryRepository.GetByIdWithDetailsAsync(request.CategoryId, cancellationToken)
            ?? throw new NotFoundException("ProductCategory", request.CategoryId);

        return category.Adapt<ProductCategoryDetailDto>();
    }
}
