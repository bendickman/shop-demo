using System.Threading.Tasks;
using static System.Console;

namespace ShopDemo.Api.Core.Commands
{
    public class QuitCommand : ICommand
    {
        public async Task ExecuteAsync()
        {
            WriteLine("Thank you for using ShopDemo");
        }
    }
}
