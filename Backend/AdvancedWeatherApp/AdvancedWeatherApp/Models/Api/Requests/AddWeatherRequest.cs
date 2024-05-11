using System.Text.Json.Serialization;
using AdvancedWeatherApp.Models.Api.DTOs;
using AdvancedWeatherApp.Models.BusinessLogic;

namespace AdvancedWeatherApp.Models.Api.Requests;

public class AddWeatherRequest
{
    [JsonPropertyName("weather")]
    public WeatherDto Weather { get; set; }

    public AddWeatherRequest(WeatherDto weather)
    {
        Weather = weather ?? throw new ArgumentNullException(nameof(weather), "Weather can not be null!");
    }
}