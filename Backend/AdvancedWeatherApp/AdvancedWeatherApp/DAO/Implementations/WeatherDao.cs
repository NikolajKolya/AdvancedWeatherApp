using AdvancedWeatherApp.DAO.Abstract;
using AdvancedWeatherApp.DAO.DBO;
using AdvancedWeatherApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvancedWeatherApp.DAO.Implementations;

public class WeatherDao: IWeatherDao
{
    private readonly MainDbContext _dbContext;

    public WeatherDao(MainDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<WeatherDbo> GetWeatherOnDateTime(DateOnly dateTime)
    {
        return await _dbContext
            .Weathers
            .Where(w => DateOnly.FromDateTime(w.DateTimeStamp) == dateTime)
            .OrderByDescending(w => w.DateTimeStamp)
            .Take(1)
            .SingleOrDefaultAsync();
    }

    public async Task<WeatherDbo> GetLastWeather()
    {
        return await _dbContext
            .Weathers
            .OrderByDescending(w => w.DateTimeStamp)
            .FirstOrDefaultAsync();
    }

    public async Task<WeatherDbo> PostWeather(WeatherDbo weatherDbo)
    {
        _ = weatherDbo ?? throw new ArgumentNullException(nameof(weatherDbo), "Weather can not be null!");

        _dbContext.Weathers.AddAsync(weatherDbo);

        await _dbContext.SaveChangesAsync();

        return weatherDbo;
    }
}