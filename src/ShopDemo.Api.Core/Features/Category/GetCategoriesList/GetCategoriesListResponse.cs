using ShopDemo.Api.Core.Data;
using ShopDemo.Shared.Base;
using System.Collections.Generic;

namespace ShopDemo.Api.Core.Features.Category.GetCategoriesList
{
    public class GetCategoriesListResponse : BaseResponse
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
    
}
