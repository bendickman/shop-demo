using AutoMapper;
using ShopDemo.Api.Core.Mappings;

namespace ShopDemo.Api.Core.Data
{
    public class ProductDto : IMapFrom<Shared.Domain.Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public int CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Shared.Domain.Product, ProductDto>();
        }
    }
}
