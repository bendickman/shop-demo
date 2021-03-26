using System.Threading.Tasks;

namespace ShopDemo.Console.Commands
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }
}
