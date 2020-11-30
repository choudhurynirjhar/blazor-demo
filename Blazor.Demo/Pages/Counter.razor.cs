using System;

namespace Blazor.Demo.Pages
{
    partial class Counter
    {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
            Console.WriteLine($"Current count: {currentCount}");
        }
    }
}
