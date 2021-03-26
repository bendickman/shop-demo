using Microsoft.AspNetCore.Mvc;
using ShopDemo.Api.Core.Features.Product.GetFeaturedProducts;
using System.Threading.Tasks;

namespace ShopDemo.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductController : BaseController
    {
        [HttpGet]
        [Route("featured")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Featured()
        {
            var response = await Mediator.Send(new GetFeaturedProductsQuery());

            return Json(response.Products);
        }
    }
}
