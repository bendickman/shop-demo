using MediatR;
using ShopDemo.Shared.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShopDemo.Api.Core.Features.Category
{
    
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesResponse>
    {
        public async Task<GetCategoriesResponse> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = new GetCategoriesResponse
            {
                Categories = new List<CategoryDto>
                {
                    new CategoryDto { Id = 1, Name = "Category 1", SKUIdentifier = 10000 },
                    new CategoryDto { Id = 2, Name = "Category 2", SKUIdentifier = 20000 },
                    new CategoryDto { Id = 3, Name = "Category 3", SKUIdentifier = 30000 },
                    new CategoryDto { Id = 4, Name = "Category 4", SKUIdentifier = 40000 },
                }
            };

            return await Task.Run(() => response);
        }
    }
    
}
