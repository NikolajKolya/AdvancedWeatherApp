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
    
    [Route("api/Weather/GetCurrentDateTime")]
    [HttpGet]
    public async Task<ActionResult<DateTime>> GetCurrentDateTimeAsync()
    {
        return Ok(DateTime.UtcNow);
    }
    
    [Route("api/Weather/PlusOne/{varToAdd}")]
    [HttpGet]
    public async Task<ActionResult<int>> PlusOneAsync(int varToAdd)
    {
        return Ok(varToAdd + 1);
    }
    
    [Route("api/Weather/{weatherPeriod}")]
    [HttpGet]
    public async Task<WeatherResponse> WeatherOnData(WeatherTypeEnum weatherPeriod)
    {
         IReadOnlyCollection<Weather> weathers = await _weatherService.GetWeather(weatherPeriod);
         
         return new WeatherResponse(weathers);
    }
}