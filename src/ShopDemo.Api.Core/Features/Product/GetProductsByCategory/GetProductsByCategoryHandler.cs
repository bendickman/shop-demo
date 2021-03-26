using AutoMapper;
using Dapper;
using MediatR;
using ShopDemo.Api.Core.Data;
using ShopDemo.Shared;
using ShopDemo.Shared.Data;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ShopDemo.Api.Core.Features.Product.GetFeaturedProducts
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryQuery, GetProductsByCategoryResponse>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDatabaseQueryProvider _queryProvider;
        private readonly IMapper _mapper;

        public GetProductsByCategoryHandler(IDbConnection dbConnection, IDatabaseQueryProvider queryProvider, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _queryProvider = queryProvider;
            _mapper = mapper;
        }

        public async Task<GetProductsByCategoryResponse> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var queryCommand = _queryProvider.GetCommand(Constants.Data.GetProductsByCategory, new { request.CategoryId });

            var commandDefinition = new CommandDefinition(queryCommand.Query, queryCommand.Parameters);

            var result =  await _dbConnection.QueryAsync<Shared.Domain.Product>(commandDefinition).ConfigureAwait(false);

            var products = _mapper.Map<IEnumerable<ProductDto>>(result);

            return new GetProductsByCategoryResponse { Products = products };
        }
    }
}
