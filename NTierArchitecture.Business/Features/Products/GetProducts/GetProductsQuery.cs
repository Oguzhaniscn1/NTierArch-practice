using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Business.Features.Products.GetProducts;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.GetProducts
{
    public sealed record GetProductsQuery():IRequest<List<Product>>;
}


internal sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
    }
}