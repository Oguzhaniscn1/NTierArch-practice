using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Categories.CreateCategory;
using NTierArchitecture.Business.Features.Categories.GetCategories;
using NTierArchitecture.Business.Features.Categories.RemoveCategoryById;
using NTierArchitecture.Business.Features.Categories.UpdateCategory;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryCommand request,CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveById(RemoveCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> GetAll(GetCategoriesCommand request, CancellationToken cancellationToken)
        {
            var response=await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }


    }
}
