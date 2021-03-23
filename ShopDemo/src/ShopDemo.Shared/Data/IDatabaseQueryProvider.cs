namespace ShopDemo.Shared.Data
{
    public interface IDatabaseQueryProvider
    {
        QueryCommand GetCommand(string key);
    }
}
