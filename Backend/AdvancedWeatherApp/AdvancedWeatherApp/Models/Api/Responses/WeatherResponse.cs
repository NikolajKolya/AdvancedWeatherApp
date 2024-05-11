using System.Text.Json.Serialization;
using AdvancedWeatherApp.Models.Api.DTOs;
using AdvancedWeatherApp.Models.Api.Requests;
using AdvancedWeatherApp.Models.BusinessLogic;

namespace AdvancedWeatherApp.Models.Api.Responses;

/// <summary>
/// List of weathers
/// </summary>
public class WeatherResponse
{
    /// <summary>
    /// List of weathers
    /// </summary>
    [JsonPropertyName("weathers")]
    public IReadOnlyCollection<WeatherDto> Weathers { get; private set; }

    public WeatherResponse
    (
        IReadOnlyCollection<WeatherDto> weathers
    )
    {
        _ = weathers ?? throw new ArgumentNullException(nameof(weathers), "Weathers list must be provided!");

        if (weathers.Any(w => w == null))
        {
            throw new ArgumentNullException(nameof(weathers), "Some of weathers items are null!");
        }

        Weathers = weathers;
    }
}