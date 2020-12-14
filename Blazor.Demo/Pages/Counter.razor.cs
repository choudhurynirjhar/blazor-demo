using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Demo.Pages
{
    partial class Counter
    {
        [Inject]
        private IDotnetToJavascript DotnetToJavascript { get; set; }

        [Inject]
        private AddressProvider AddressProvider { get; set; }

        private int currentCount = 0;

        private async Task IncrementCount()
        {
            currentCount++;
            Console.WriteLine($"Current count: {currentCount}");
            await DotnetToJavascript.PrintAsync(currentCount);
            await DotnetToJavascript.PrintFormattedMessage();
        }

        [JSInvokable]
        public static Task<string> HelpMessage()
        {
            return Task.FromResult("Help text from C# static function");
        }

        private async Task CallInstanceMethod()
        {
            await AddressProvider.Register();
        }
    }
}
