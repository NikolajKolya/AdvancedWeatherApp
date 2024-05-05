using AdvancedWeatherApp.DAO.DBO;
using AdvancedWeatherApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWeatherApp.DAO.Abstract;

public interface IWeatherDao
{
    #region Get references
    
    /// <summary>
    /// Get last weather ID
    /// </summary>
    public Task<Guid> GetLastWeatherIdAsync();

    /// <summary>
    /// Get all weathers IDs
    /// </summary>
    public Task<IReadOnlyCollection<Guid>> GetAllWeatherIdsAsync();
    
    #endregion

    #region Add weathers

    /// <summary>
    /// Add weather to DB
    /// </summary>
    public Task<WeatherDbo> PostWeatherAsync(WeatherDbo weatherDbo);

    #endregion

    #region Get weathers

    /// <summary>
    /// Get weathers by IDs
    /// </summary>
    public Task<IReadOnlyCollection<WeatherDbo>> GetWeathersByIdsAsync(IReadOnlyCollection<Guid> ids);

    #endregion
    
}