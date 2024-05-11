using System.Text.Json.Serialization;

namespace AdvancedWeatherApp.Models.Api.DTOs;

/// <summary>
/// Weather Data Transfer Object
/// </summary>
public class WeatherDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }
    
    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }
    
    [JsonPropertyName("pressure")]
    public double Pressure { get; set; }
	
    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }

    public WeatherDto
    (
        Guid id,
        DateTime timestamp,
        double temperature,
        double pressure,
        double humidity
    )
    {
        Id = id;
        Timestamp = timestamp;
        Temperature = temperature;
        Pressure = pressure;
        Humidity = humidity;
    }
}