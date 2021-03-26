using ShopDemo.Shared;
using ShopDemo.Shared.Domain;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace ShopDemo.Console.Commands
{
    public class FeaturedProductsCommand : ICommand
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeaturedProductsCommand(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task ExecuteAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(Constants.Data.ShopDemoClientName);

            var response = await httpClient.GetAsync(Constants.Data.GetFeaturedProductsUrl).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var products = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>(result);

                foreach (var product in products)
                {
                    WriteLine($"Id: {product.Id}\tName: {product.Name}\tPrice: {product.Price.ToString("C")}");
                }
            }
            else
                WriteLine("Error fetching product categories.");
        }
    }
}
