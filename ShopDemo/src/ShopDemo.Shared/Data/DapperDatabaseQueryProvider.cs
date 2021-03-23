using System.Collections.Generic;

namespace ShopDemo.Shared.Data
{
    public class DapperDatabaseQueryProvider : IDatabaseQueryProvider
    {
        private Dictionary<string, string> Commands;

        public DapperDatabaseQueryProvider()
        {
            Commands = new Dictionary<string, string>
            {
                { Constants.Data.GetCategories, "EXEC [dbo].[usp_GetCategories]" },
                { Constants.Data.GetFeaturedProducts, "EXEC [dbo].[usp_GetFeaturedProducts]" }
            };

        }

        public QueryCommand GetCommand(string key)
        {
            if (Commands.TryGetValue(key, out var query))
            {
                return new QueryCommand { Query = query };
            }

            return null;

        }
    }
}
