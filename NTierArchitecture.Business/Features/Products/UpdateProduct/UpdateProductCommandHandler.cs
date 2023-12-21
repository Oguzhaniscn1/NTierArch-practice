using AutoMapper;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(p=>p.Id==request.Id,cancellationToken);
        if (product is null)
        {
            throw new ArgumentException("ürün bulunamadı");
        }

        if(product.Name!=request.Name)
        {
            bool isProductExist = await _productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isProductExist)
            {
                throw new ArgumentException("ürün adı daha önce kullanılmış");
            }
        }

        _mapper.Map(request, product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }
}
