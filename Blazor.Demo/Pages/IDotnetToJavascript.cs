using System.Threading.Tasks;

namespace Blazor.Demo.Pages
{
    public interface IDotnetToJavascript
    {
        Task PrintAsync(int counter);

        Task PrintFormattedMessage();
    }
}