using Microsoft.Extensions.Configuration;

namespace ShopDemo.Api
{
    public class ApplicationSettings
    {
        private readonly IConfiguration _configuration;

        public ApplicationSettings(IConfiguration configuration)
        {
            _configuration = configuration;

            ConnectionString = _configuration.GetConnectionString(Constants.ConnectionStringKey);

            configuration.Bind(this);
        }
        public string ConnectionString { get; set; }
    }

    
}
