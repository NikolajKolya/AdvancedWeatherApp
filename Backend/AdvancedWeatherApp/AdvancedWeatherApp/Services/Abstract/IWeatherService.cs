using AdvancedWeatherApp.Models;
using AdvancedWeatherApp.Models.Enums;
using AdvancedWeatherApp.Models.Responses;
using AdvancedWeatherApp.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWeatherApp.Services.Abstract;

public interface IWeatherService
{
    public Task<IReadOnlyCollection<Weather>> GetWeather(WeatherTypeEnum weatherTypeEnum);
}