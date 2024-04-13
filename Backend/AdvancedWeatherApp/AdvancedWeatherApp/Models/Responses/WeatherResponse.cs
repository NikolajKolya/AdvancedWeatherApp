using System.Text.Json.Serialization;

namespace AdvancedWeatherApp.Models.Responses;

public class WeatherResponse
{
    [JsonPropertyName("weathers")]
    public IReadOnlyCollection<Weather>? Weathers { get; }

    public WeatherResponse(IReadOnlyCollection<Weather> weathers)
    {
        Weathers = weathers
                   ?? throw new ArgumentNullException(nameof(weathers), "weathers items must be populated!");
        if (!Weathers.Any())
        {
            throw new ArgumentException("Weather must be no empty!");
        }
    }
}