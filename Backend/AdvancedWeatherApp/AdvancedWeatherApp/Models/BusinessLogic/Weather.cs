using AdvancedWeatherApp.Models.Api.DTOs;

namespace AdvancedWeatherApp.Models.BusinessLogic;

/// <summary>
/// Weather model
/// </summary>
public class Weather
{
    /// <summary>
    /// Weather ID
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Weather timestamp
    /// </summary>
    public DateTime Timestamp { get; private set; }
    
    /// <summary>
    /// Temperature
    /// </summary>
    public double Temperature { get; private set; }
    
    /// <summary>
    /// Pressure
    /// </summary>
    public double Pressure { get; private set; }
    
    /// <summary>
    /// Humidity
    /// </summary>
    public double Humidity { get; private set; }

    public Weather
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

        if (temperature < -273.15 || temperature > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(temperature), temperature, "Too cold or too hot!");
        }

        Temperature = temperature;

        if (pressure < 0 || pressure > 2000)
        {
            throw new ArgumentOutOfRangeException(nameof(pressure), pressure, "Wrong pressure!");
        }
        
        Pressure = pressure;

        if (humidity < 0 || humidity > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(humidity), humidity, "Too dry or too wet!");
        }

        Humidity = humidity;
    }

    /// <summary>
    /// Convert model to DTO
    /// </summary>
    public WeatherDto ToDto()
    {
        return new WeatherDto
        (
            Id,
            Timestamp,
            Temperature,
            Pressure,
            Humidity
        );
    }
}