using System.Threading.Tasks;

namespace Blazor.Demo.Pages
{
    public interface IWeatherProvider
    {
        Task<WeatherForecast[]> GetAsync();
    }
}