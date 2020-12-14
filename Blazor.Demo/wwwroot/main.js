(function (window) {
    window.logUser =
        window.logUser ||
        function (counter) {
            console.log(`Printing in JavaScript counter: ${counter}`);
        }

    window.getFormattedMessage =
        window.getFormattedMessage ||
        function () {
            return "Hello from JavaScript to C#";
        }

    window.invokeDotnetStaticFunction =
        window.invokeDotnetStaticFunction ||
        function () {
            DotNet.invokeMethodAsync('Blazor.Demo', 'HelpMessage')
                .then(data => { console.log(data); });
        }

    window.invokeDotnetInstanceFunction =
        window.invokeDotnetInstanceFunction ||
        function (addressProvider) {
            addressProvider.invokeMethodAsync("GetAddress")
                .then(data => { console.log(data); });
        }

})(window);