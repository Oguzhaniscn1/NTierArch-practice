using AutoMapper;
using MediatR;
using NTierArchitecture.Business.Features.Products.CreateProduct;
using NTierArchitecture.Entities.Models;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        bool isProductNameExist = await _productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isProductNameExist)
        {
            throw new ArgumentException("bu ürün adı daha önce kullanılmış");
        }

        Product product =_mapper.Map<Product>(request);

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);


    }
}
