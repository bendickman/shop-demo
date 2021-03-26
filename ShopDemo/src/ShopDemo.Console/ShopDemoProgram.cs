using ShopDemo.Console.Commands;
using System.Threading.Tasks;
using static System.Console;

namespace ShopDemo.Console
{
    public class ShopDemoProgram : IProgramRunnable
    {
        private readonly ICommandProvider _commandProvider;

        public ShopDemoProgram(ICommandProvider commandProvider)
        {
            _commandProvider = commandProvider;
        }

        public async Task Run()
        {
            var input = string.Empty;

            while (input != "q")
            {
                WriteLine("Welcome to the ShopDemo");
                WriteLine("Enter 'b' to list the product categories.");
                WriteLine("Enter 'c' to list the featured products.");
                WriteLine("Enter 'd' to list the products by their categories.");
                WriteLine("Enter 'q' to quit the program.");

                WriteLine("Please enter an option:");

                input = ReadKey().KeyChar.ToString().ToLower();

                Clear();

                var provider = _commandProvider.GetCommand(input);

                if (provider != null)
                    await provider.ExecuteAsync().ConfigureAwait(false);

                WriteLine();
            }
        }
    }
}
