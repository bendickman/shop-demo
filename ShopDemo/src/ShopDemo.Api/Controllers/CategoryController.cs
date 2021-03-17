using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ShopDemo.Api.Core.Features.Category;

namespace ShopDemo.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/category")]
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new List.GetCategoriesQuery());

            return Json(response);
        }
    }
}
