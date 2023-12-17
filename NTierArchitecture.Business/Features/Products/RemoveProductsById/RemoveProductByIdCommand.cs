using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Products.RemoveProductsById;

public sealed record RemoveProductsByIdCommand(Guid Id):IRequest;
