namespace ShopDemo.Api.Core.Commands
{
    public interface ICommandProvider
    {
        ICommand GetCommand(string key);
    }
}
