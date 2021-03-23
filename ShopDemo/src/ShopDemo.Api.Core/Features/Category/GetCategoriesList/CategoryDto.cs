using AutoMapper;
using ShopDemo.Api.Core.Mappings;

namespace ShopDemo.Api.Core.Features.Category.GetCategoriesList
{
    public class CategoryDto : IMapFrom<Shared.Domain.Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public int SkuPrefix { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Shared.Domain.Category, CategoryDto>();
        }
    }
}
