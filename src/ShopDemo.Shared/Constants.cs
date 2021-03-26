namespace ShopDemo.Shared
{
    public static class Constants
    {
        public static class Data
        {
            public const string GetCategories = nameof(GetCategories);
            public const string GetFeaturedProducts = nameof(GetFeaturedProducts);
            public const string GetProductsByCategory = nameof(GetProductsByCategory);

            public const string GetCategoriesUrl = "categories";
            public const string GetFeaturedProductsUrl = "products/featured";
            public const string GetProductsByCategoryUrl = "categories/{0}/products";

            public const string ShopDemoClientName = "ShopDemoClient";

            public const string EnvironmentVariableApiBaseUrl = "API_BASE_URL";
        }

        
    }
}
