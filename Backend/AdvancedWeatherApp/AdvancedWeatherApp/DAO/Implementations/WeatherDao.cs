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

    public async Task<IReadOnlyCollection<WeatherDbo>> GetWeathersByIdsAsync(IReadOnlyCollection<Guid> ids)
    {
        return await _dbContext
            .Weathers
            .Where(w => ids.Any(id => id == w.Id))
            .ToListAsync();
    }

    public async Task<Guid> GetLastWeatherIdAsync()
    {
        return await _dbContext
            .Weathers
            .OrderByDescending(w => w.DateTimeStamp)
            .Select(w => w.Id)
            .FirstAsync();
    }

    public async Task<IReadOnlyCollection<Guid>> GetAllWeatherIdsAsync()
    {
        return await _dbContext
            .Weathers
            .Select(w => w.Id)
            .ToListAsync();
    }

    public async Task<WeatherDbo> PostWeatherAsync(WeatherDbo weatherDbo)
    {
        _ = weatherDbo ?? throw new ArgumentNullException(nameof(weatherDbo), "Weather can not be null!");

        await _dbContext.Weathers.AddAsync(weatherDbo);

        await _dbContext.SaveChangesAsync();

        return weatherDbo;
    }
}