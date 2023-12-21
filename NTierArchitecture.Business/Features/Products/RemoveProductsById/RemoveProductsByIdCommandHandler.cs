using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Products.RemoveProductsById;

internal sealed class RemoveProductsByIdCommandHandler : IRequestHandler<RemoveProductsByIdCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductsByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task Handle(RemoveProductsByIdCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(p=>p.Id==request.Id,cancellationToken);
        if (product is null)
        {
            throw new ArgumentException("ürün bulunamadı");
        }

        _productRepository.Remove(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
