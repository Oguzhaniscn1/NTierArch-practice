using AutoMapper;
using MediatR;
using NTierArchitecture.Business.Features.Categories.UpdateCategory;
using NTierArchitecture.Entities.Models;

internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

        //category.Name= request.Name;

        _mapper.Map(request, category);//requesti set eder categoryde değişmeyenleri aynı şekilde bırakır.

        await _unitOfWork.SaveChangesAsync(cancellationToken);


    }
}
