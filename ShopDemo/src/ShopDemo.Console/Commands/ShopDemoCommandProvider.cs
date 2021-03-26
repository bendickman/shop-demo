using System.Collections.Generic;
using System.Linq;

namespace ShopDemo.Console.Commands
{
    class ShopDemoCommandProvider : ICommandProvider
    {
        private IEnumerable<ICommand> _commands;
        private Dictionary<string, ICommand> _commandLookup;

        public ShopDemoCommandProvider(IEnumerable<ICommand> commands)
        {
            _commands = commands;
            SetCommandsLookup();
        }

        private void SetCommandsLookup()
        {
            _commandLookup = new Dictionary<string, ICommand>
            {
                { "b", _commands.OfType<CategoriesCommand>().FirstOrDefault()},
                { "c", _commands.OfType<FeaturedProductsCommand>().FirstOrDefault()},
                { "d", _commands.OfType<ProductsByCategoryCommand>().FirstOrDefault()},
                { "q", _commands.OfType<QuitCommand>().FirstOrDefault()},
            };
        }

        public ICommand GetCommand(string key)
        {
            if (_commandLookup.TryGetValue(key, out var command))
                return command;

            return _commandLookup.OfType<NotFoundCommand>().FirstOrDefault();
        }
    }
}
