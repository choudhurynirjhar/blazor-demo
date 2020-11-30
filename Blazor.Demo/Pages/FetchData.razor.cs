using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace Blazor.Demo.Pages
{
    partial class FetchData
    {
        [Inject]
        private IWeatherProvider WeatherProvider { get; set; }

        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await WeatherProvider.GetAsync();
        }

        
    }
}
