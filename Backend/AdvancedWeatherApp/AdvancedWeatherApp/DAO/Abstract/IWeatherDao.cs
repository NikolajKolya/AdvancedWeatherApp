using AdvancedWeatherApp.DAO.DBO;
using AdvancedWeatherApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWeatherApp.DAO.Abstract;

public interface IWeatherDao
{
    public Task<WeatherDbo> GetWeatherOnDateTime(DateOnly dateTime);

    public Task<WeatherDbo> PostWeather(WeatherDbo weatherDbo);

    public Task<WeatherDbo> GetLastWeather();
}