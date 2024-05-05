using System.Text.Json.Serialization;
using AdvancedWeatherApp.Models.Api.DTOs;

namespace AdvancedWeatherApp.Models.Api.Responses;

/// <summary>
/// Response for GetLastWeatherReferenceAsync()
/// </summary>
public class LastWeatherReferenceResponse
{
    /// <summary>
    /// Is last weather exists
    /// </summary>
    [JsonPropertyName("isLastWeatherExists")]
    public bool IsLastWeatherExists { get; private set; }

    /// <summary>
    /// Reference itself
    /// </summary>
    [JsonPropertyName("weatherReference")]
    public WeatherReferenceDto WeatherReferenceDto { get; private set; }

    public LastWeatherReferenceResponse
    (
        bool isLastWeatherExists,
        WeatherReferenceDto weatherReferenceDto
    )
    {
        IsLastWeatherExists = isLastWeatherExists;

        if (isLastWeatherExists && weatherReferenceDto == null)
        {
            throw new ArgumentException
            (
                "Weather reference is declared as existing, but not provided!",
                nameof(weatherReferenceDto)
            );
        }

        WeatherReferenceDto = weatherReferenceDto;
    }
}