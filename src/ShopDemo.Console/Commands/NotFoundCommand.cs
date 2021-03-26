using System.Threading.Tasks;
using static System.Console;

namespace ShopDemo.Console.Commands
{
    public class NotFoundCommand : ICommand
    {
        public async Task ExecuteAsync()
        {
            WriteLine("Sorry, the command is not recognised.");
        }
    }
}
