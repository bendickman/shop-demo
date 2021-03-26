using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ShopDemo.Api.Core.Features.Category.GetCategoriesList;
using ShopDemo.Api.Core.Features.Product.GetFeaturedProducts;

namespace ShopDemo.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/categories")]
    public class CategoryController : BaseController
    {
        [HttpGet]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> List()
        {
            var response = await Mediator.Send(new GetCategoriesListQuery());

            return Json(response.Categories);
        }

        [HttpGet]
        [Route("{categoryId}/products")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> ProductsByCategory(int categoryId)
        {
            var response = await Mediator.Send(new GetProductsByCategoryQuery { CategoryId = categoryId }).ConfigureAwait(false);

            return Json(response.Products);
        }
    }
}
