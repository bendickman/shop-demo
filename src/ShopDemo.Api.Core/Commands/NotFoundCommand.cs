using System.Threading.Tasks;
using static System.Console;

namespace ShopDemo.Api.Core.Commands
{
    public class NotFoundCommand : ICommand
    {
        public async Task ExecuteAsync()
        {
            WriteLine("Sorry, the command is not recognised.");
        }
    }
}
