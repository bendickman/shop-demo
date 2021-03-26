using ShopDemo.Api.Core.Data;
using System.Collections.Generic;

namespace ShopDemo.Api.Core.Features.Product.GetFeaturedProducts
{
    public class GetFeaturedProductsResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
