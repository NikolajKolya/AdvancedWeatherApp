using AdvancedWeatherApp.DAO.DBO;
using AdvancedWeatherApp.Models;
using AdvancedWeatherApp.Models.Responses;

namespace AdvancedWeatherApp.Mappers.Abstract;

public interface IWeatherMapper
{
    public Weather Map(WeatherDbo weatherDto);
    
    public WeatherDbo Map(Weather weather);
    
    public IReadOnlyCollection<WeatherDbo> Map(IReadOnlyCollection<Weather> weathers);

    public IReadOnlyCollection<Weather> Map(IReadOnlyCollection<WeatherDbo> weathersDao);
}