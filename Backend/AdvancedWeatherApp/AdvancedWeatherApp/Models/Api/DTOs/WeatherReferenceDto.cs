using System.Text.Json.Serialization;

namespace AdvancedWeatherApp.Models.Api.DTOs;

/// <summary>
/// Reference to a weather
/// </summary>
public class WeatherReferenceDto
{
    [JsonPropertyName("weatherId")]
    public Guid WeatherId { get; private set; }

    public WeatherReferenceDto
    (
        Guid weatherId
    )
    {
        WeatherId = weatherId;
    }
}