using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Blazor.Demo.Pages
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherProvider> _logger;

        public WeatherProvider(HttpClient httpClient, ILogger<WeatherProvider> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<WeatherForecast[]> GetAsync()
        {
            _logger.LogInformation("Getting data from server");
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }
}
