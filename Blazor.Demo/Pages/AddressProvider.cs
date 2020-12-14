using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Demo.Pages
{
    public class AddressProvider : IDisposable
    {
        private readonly IJSRuntime jSRuntime;
        private DotNetObjectReference<AddressProvider> objectReference;

        public AddressProvider(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task Register()
        {
            objectReference = DotNetObjectReference.Create(this);
            await jSRuntime.InvokeVoidAsync("invokeDotnetInstanceFunction", objectReference);
        }

        [JSInvokable]
        public string GetAddress()
        {
            return "123 Main Street";    
        }

        public void Dispose()
        {
            objectReference.Dispose();
        }
    }
}
