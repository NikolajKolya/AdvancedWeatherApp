using AdvancedWeatherApp.DAO.DBO;
using AdvancedWeatherApp.Mappers.Abstract;
using AdvancedWeatherApp.Models;

namespace AdvancedWeatherApp.Mappers.Implementation;

public class WeatherMapper: IWeatherMapper
{
    public Weather Map(WeatherDbo weatherDbo)
    {
        return new Weather()
        {
            Id = weatherDbo.Id,
            Temperature = weatherDbo.Temperature,
            DateTimeStamp = weatherDbo.DateTimeStamp,
            Humidity = weatherDbo.Humidity,
            Pressure = weatherDbo.Pressure 
        };
    }

    public WeatherDbo Map(Weather weather)
    {
        return new WeatherDbo()
        {
            Id = weather.Id,
            Temperature = weather.Temperature,
            DateTimeStamp = weather.DateTimeStamp,
            Humidity = weather.Humidity,
            Pressure = weather.Pressure
        };
    }

    public IReadOnlyCollection<WeatherDbo> Map(IReadOnlyCollection<Weather> weathers)
    {
        return weathers.Select(Map).ToList();
    }

    public IReadOnlyCollection<Weather> Map(IReadOnlyCollection<WeatherDbo> weathersDao)
    {
        return weathersDao.Select(Map).ToList();
    }
}