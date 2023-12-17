using MediatR;
using NTierArchitecture.Business.Features.Categories.CreateCategory;
using NTierArchitecture.Entities.Models;

internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

        var isCategoryNameExist = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if(isCategoryNameExist)
        {
            throw new ArgumentException("bu kategori daha önce oluşturuldu");
        }


        Category category = new()
        {
            Name = request.Name,

        };
        
        await _categoryRepository.AddAsync(category,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
