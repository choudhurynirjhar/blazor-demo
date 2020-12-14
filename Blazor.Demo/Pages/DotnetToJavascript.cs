using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazor.Demo.Pages
{
    public class DotnetToJavascript : IDotnetToJavascript
    {
        private readonly IJSRuntime iJSRuntime;
        private readonly ILogger<DotnetToJavascript> logger;

        public DotnetToJavascript(IJSRuntime iJSRuntime,
            ILogger<DotnetToJavascript> logger)
        {
            this.iJSRuntime = iJSRuntime;
            this.logger = logger;
        }

        public async Task PrintAsync(int counter)
        {
            await iJSRuntime.InvokeVoidAsync("logUser", counter);
        }

        public async Task PrintFormattedMessage()
        {
            var message = await iJSRuntime.InvokeAsync<string>("getFormattedMessage");
            logger.LogInformation(message);
        }
    }
}
