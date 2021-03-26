using MediatR;

namespace ShopDemo.Api.Core.Features.Product.GetFeaturedProducts
{
    public class GetProductsByCategoryQuery : IRequest<GetProductsByCategoryResponse>
    {
        public int CategoryId { get; set; }
    }
}
