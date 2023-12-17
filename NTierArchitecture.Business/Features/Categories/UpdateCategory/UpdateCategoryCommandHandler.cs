using MediatR;
using NTierArchitecture.Business.Features.Categories.UpdateCategory;
using NTierArchitecture.Entities.Models;

internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;   
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
        if (category is null) 
        {
            throw new ArgumentException("kategori bulunamadı");
        }
        if(category.Name!=request.Name)
        {
            var isCategoryNameExist = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isCategoryNameExist)
            {
                throw new ArgumentException("bu kategori daha önce oluşturuldu");
            }
        }

        category.Name= request.Name;
        await _unitOfWork.SaveChangesAsync(cancellationToken);


    }
}
