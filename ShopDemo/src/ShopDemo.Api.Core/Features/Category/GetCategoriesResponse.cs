using ShopDemo.Shared.Base;
using ShopDemo.Shared.Dto;
using System.Collections.Generic;

namespace ShopDemo.Api.Core.Features.Category
{
    public class GetCategoriesResponse : BaseResponse
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
    
}
