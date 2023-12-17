using MediatR;
using NTierArchitecture.Business.Features.Products.CreateProduct;
using NTierArchitecture.Entities.Models;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        bool isProductNameExist = await _productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isProductNameExist)
        {
            throw new ArgumentException("bu ürün adı daha önce kullanılmış");
        }

        Product product = new()
        {
            Name = request.Name, 
            Price = request.Price,
            Quantity = request.Quantity,
            CategoryId = request.CategoryId,

        };

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);


    }
}
