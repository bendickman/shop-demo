namespace ShopDemo.Console.Commands
{
    public interface ICommandProvider
    {
        ICommand GetCommand(string key);
    }
}
