using AdvancedWeatherApp.Models;
using AdvancedWeatherApp.Models.Enums;
using AdvancedWeatherApp.Models.Responses;
using AdvancedWeatherApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWeatherApp.Controllers;

/// <summary>
/// Controller to work with weather
/// </summary>
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [Route("api/Weather/{forecastPeriod}")]
    [HttpGet]
    public async Task<WeatherResponse> WeatherOnData(WeatherTypeEnum forecastPeriod)
    {
         IReadOnlyCollection<Weather> weathers = await _weatherService.GetWeather(forecastPeriod);
         
         return new WeatherResponse(weathers);
    }
}