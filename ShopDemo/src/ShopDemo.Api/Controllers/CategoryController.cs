using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ShopDemo.Api.Core.Features.Category.GetCategoriesList;

namespace ShopDemo.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/categories")]
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await Mediator.Send(new GetCategoriesListQuery());

            return Json(response);
        }
    }
}
