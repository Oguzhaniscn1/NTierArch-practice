using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Categories.GetCategories;

internal sealed class GetCategoriesHandler : IRequestHandler<GetCategoriesCommand, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
    }
}
