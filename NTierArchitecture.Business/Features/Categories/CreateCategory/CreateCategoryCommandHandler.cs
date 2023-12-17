using AutoMapper;
using MediatR;
using NTierArchitecture.Business.Features.Categories.CreateCategory;
using NTierArchitecture.Entities.Models;

internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

        var isCategoryNameExist = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if(isCategoryNameExist)
        {
            throw new ArgumentException("bu kategori daha önce oluşturuldu");
        }


        Category category = _mapper.Map<Category>(request);
        
        await _categoryRepository.AddAsync(category,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
