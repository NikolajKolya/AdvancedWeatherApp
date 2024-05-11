using Weather = AdvancedWeatherApp.Models.BusinessLogic.Weather;

namespace AdvancedWeatherApp.Services.Abstract;

public interface IWeatherService
{
    /// <summary>
    /// Get weather by ids list. Throws an exception if weather with given ID is not exist
    /// </summary>
    Task<IReadOnlyCollection<Weather>> GetWeathersByIdsAsync(IReadOnlyCollection<Guid> ids);
    
    /// <summary>
    /// Get last weather ID
    /// </summary>
    Task<Guid> GetLastWeatherIdAsync();

    /// <summary>
    /// Get all weathers IDs
    /// </summary>
    Task<IReadOnlyCollection<Guid>> GetAllWeathersIdsAsync();

    Task AddNewWeatherAsync(Weather weather);
}