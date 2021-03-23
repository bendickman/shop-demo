using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using ShopDemo.Shared.Data;
using ShopDemo.Shared;
using AutoMapper;
using System.Collections.Generic;

namespace ShopDemo.Api.Core.Features.Category.GetCategoriesList
{
    public class GetCategoriesListHandler : IRequestHandler<GetCategoriesListQuery, GetCategoriesListResponse>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDatabaseQueryProvider _queryProvider;
        private readonly IMapper _mapper;

        public GetCategoriesListHandler(IDbConnection dbConnection, IDatabaseQueryProvider queryProvider, IMapper mapper)
        {
            _dbConnection = dbConnection;
            _queryProvider = queryProvider;
            _mapper = mapper;
        }

        public async Task<GetCategoriesListResponse> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var queryCommand = _queryProvider.GetCommand(Constants.Data.GetCategories);

            var commandDefinition = new CommandDefinition(queryCommand.Query, queryCommand.Parameters);

            var result = await _dbConnection.QueryAsync<Shared.Domain.Category>(commandDefinition).ConfigureAwait(false);

            var categories = _mapper.Map<IEnumerable<CategoryDto>>(result);

            return new GetCategoriesListResponse { Categories = categories };
        }
    }
    
}
