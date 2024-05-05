using AdvancedWeatherApp.DAO.DBO;
using AdvancedWeatherApp.Models;
using AdvancedWeatherApp.Models.Api.DTOs;
using AdvancedWeatherApp.Models.BusinessLogic;

namespace AdvancedWeatherApp.Mappers.Abstract;

public interface IWeatherMapper
{
    public Weather Map(WeatherDto weatherDto);
    
    public Weather Map(WeatherDbo weatherDbo);
    
    public WeatherDto MapToDto(Weather weather);
    
    public WeatherDbo MapToDbo(Weather weather);
    
    public IReadOnlyCollection<WeatherDbo> MapToDbo(IReadOnlyCollection<Weather> weathers);
    
    public IReadOnlyCollection<WeatherDto> MapToDto(IReadOnlyCollection<Weather> weathers);

    public IReadOnlyCollection<Weather> Map(IReadOnlyCollection<WeatherDbo> weathersDbo);
    
    public IReadOnlyCollection<Weather> Map(IReadOnlyCollection<WeatherDto> weathersDto);
}