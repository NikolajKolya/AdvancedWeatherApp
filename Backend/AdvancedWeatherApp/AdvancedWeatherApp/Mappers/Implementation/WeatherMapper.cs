using AdvancedWeatherApp.DAO.DBO;
using AdvancedWeatherApp.Mappers.Abstract;
using AdvancedWeatherApp.Models;
using AdvancedWeatherApp.Models.Api.DTOs;
using AdvancedWeatherApp.Models.BusinessLogic;

namespace AdvancedWeatherApp.Mappers.Implementation;

public class WeatherMapper: IWeatherMapper
{
    public Weather Map(WeatherDto weatherDto)
    {
        return new Weather
        (
            weatherDto.Id,
            weatherDto.Timestamp,
            weatherDto.Temperature,
            weatherDto.Pressure,
            weatherDto.Humidity
        );
    }

    public Weather Map(WeatherDbo weatherDbo)
    {
        return new Weather
        (
            weatherDbo.Id,
            weatherDbo.DateTimeStamp,
            weatherDbo.Temperature,
            weatherDbo.Pressure,
            weatherDbo.Humidity
        );
    }

    public WeatherDto MapToDto(Weather weather)
    {
        return new WeatherDto()
        {
            Id = weather.Id,
            Temperature = weather.Temperature,
            Timestamp = weather.Timestamp,
            Humidity = weather.Humidity,
            Pressure = weather.Pressure 
        };
    }

    public WeatherDbo MapToDbo(Weather weather)
    {
        return new WeatherDbo()
        {
            Id = weather.Id,
            Temperature = weather.Temperature,
            DateTimeStamp = weather.Timestamp,
            Humidity = weather.Humidity,
            Pressure = weather.Pressure 
        };
    }

    public IReadOnlyCollection<WeatherDbo> MapToDbo(IReadOnlyCollection<Weather> weathers)
    {
        return weathers.Select(MapToDbo).ToList();
    }

    public IReadOnlyCollection<WeatherDto> MapToDto(IReadOnlyCollection<Weather> weathers)
    {
        return weathers.Select(MapToDto).ToList();
    }
    

    public IReadOnlyCollection<Weather> Map(IReadOnlyCollection<WeatherDbo> weathersDbo)
    {
        return weathersDbo.Select(Map).ToList();
    }

    public IReadOnlyCollection<Weather> Map(IReadOnlyCollection<WeatherDto> weathersDto)
    {
        return weathersDto.Select(Map).ToList();
    }
}