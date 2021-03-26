using ShopDemo.Shared;
using ShopDemo.Shared.Domain;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace ShopDemo.Console.Commands
{
    public class ProductsByCategoryCommand : ICommand
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsByCategoryCommand(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task ExecuteAsync()
        {
            WriteLine("Please enter the category Id followed by Enter");

            var input = ReadLine();

            if (!int.TryParse(input, out var categoryId))
            {
                WriteLine("Sorry, that category Id is invalid");
                return;
            }

            var httpClient = _httpClientFactory.CreateClient(Constants.Data.ShopDemoClientName);

            var response = await httpClient.GetAsync(string.Format(Constants.Data.GetProductsByCategoryUrl, categoryId)).ConfigureAwait(false);

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
                WriteLine("Error fetching products for category.");
        }
    }
}
