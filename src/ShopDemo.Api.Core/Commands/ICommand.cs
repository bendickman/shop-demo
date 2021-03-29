using System.Threading.Tasks;

namespace ShopDemo.Api.Core.Commands
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }
}
