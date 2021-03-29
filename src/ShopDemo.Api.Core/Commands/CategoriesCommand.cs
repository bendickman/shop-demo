using ShopDemo.Shared;
using ShopDemo.Shared.Domain;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace ShopDemo.Api.Core.Commands
{
    public class CategoriesCommand : ICommand
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoriesCommand(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task ExecuteAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(Constants.Data.ShopDemoClientName);

            var response = await httpClient.GetAsync(Constants.Data.GetCategoriesUrl).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var categories = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Category>>(result);

                foreach (var category in categories)
                {
                    WriteLine($"Id: {category.Id}\tName: {category.Name}\tSku: {category.Sku}\tSku Prefix: {category.SkuPrefix}");
                }
            }
            else
                WriteLine("Error fetching product categories.");
        }
    }
}
