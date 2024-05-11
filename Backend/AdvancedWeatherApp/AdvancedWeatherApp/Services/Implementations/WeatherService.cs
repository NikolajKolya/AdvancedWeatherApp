using System.Linq.Expressions;
using AdvancedWeatherApp.DAO.Abstract;
using AdvancedWeatherApp.DAO.Implementations;
using AdvancedWeatherApp.Mappers.Abstract;
using AdvancedWeatherApp.Models;
using AdvancedWeatherApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Weather = AdvancedWeatherApp.Models.BusinessLogic.Weather;

namespace AdvancedWeatherApp.Services.Implementations;

public class WeatherService: IWeatherService
{
    private IWeatherDao _weatherDao;
    private IWeatherMapper _weatherMapper;
    
    public WeatherService(IWeatherDao weatherDao, IWeatherMapper weatherMapper)
    {
        _weatherDao = weatherDao;
        _weatherMapper = weatherMapper;
    }

    public async Task<IReadOnlyCollection<Weather>> GetWeathersByIdsAsync(IReadOnlyCollection<Guid> ids)
    {
        _ = ids ?? throw new ArgumentNullException(nameof(ids), "IDs have to be provided!");

        if (ids.Distinct().Count() != ids.Count)
        {
            throw new ArgumentException("Some IDs are repeating!", nameof(ids));
        }

        var result = _weatherMapper.Map(await _weatherDao.GetWeathersByIdsAsync(ids));

        if (result.Count != ids.Count)
        {
            throw new ArgumentException("Some weathers aren't exist!", nameof(ids));
        }

        return result;
    }

    public async Task<Guid> GetLastWeatherIdAsync()
    {
        return await _weatherDao.GetLastWeatherIdAsync();
    }

    public async Task<IReadOnlyCollection<Guid>> GetAllWeathersIdsAsync()
    {
        return await _weatherDao.GetAllWeatherIdsAsync();
    }

    public async Task AddNewWeatherAsync(Weather weather)
    {
        await _weatherDao.PostWeatherAsync(_weatherMapper.MapToDbo(weather));
    }
}