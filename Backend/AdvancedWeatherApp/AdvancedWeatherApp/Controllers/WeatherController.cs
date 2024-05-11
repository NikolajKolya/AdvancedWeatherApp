using AdvancedWeatherApp.Mappers.Abstract;
using AdvancedWeatherApp.Models;
using AdvancedWeatherApp.Models.Api.DTOs;
using AdvancedWeatherApp.Models.Api.Requests;
using AdvancedWeatherApp.Models.Api.Responses;
using AdvancedWeatherApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Weather = AdvancedWeatherApp.Models.BusinessLogic.Weather;

namespace AdvancedWeatherApp.Controllers;

/// <summary>
/// Controller to work with weather
/// </summary>
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    private readonly IWeatherMapper _weatherMapper;

    public WeatherController(IWeatherService weatherService, IWeatherMapper weatherMapper)
    {
        _weatherService = weatherService;
        _weatherMapper = weatherMapper;
    }

    /// <summary>
    /// Get weathers by Ids
    /// </summary>
    [Route("api/Weathers/Get/ByIds")]
    [HttpPost]
    public async Task<ActionResult<WeatherResponse>> GetWeathersByIdAsync([FromBody] GetWeathersByIdsRequest request)
    {
        if (!request.RequestedWeathersIds.Any())
        {
            return BadRequest("At least one ID have to be provided!");
        }

        try
        {
            var weathers = await _weatherService.GetWeathersByIdsAsync(request.RequestedWeathersIds.ToList());

            return Ok
            (
                new WeatherResponse
                (
                    weathers.Select(_weatherMapper.MapToDto).ToList()
                )
            );
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest("Some arguments are null!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest("Some arguments are wrong!");
        }
    }

    /// <summary>
    /// Get last weather reference
    /// </summary>
    [Route("api/Weathers/References/Last")]
    [HttpGet]
    public async Task<ActionResult<LastWeatherReferenceResponse>> GetLastWeatherReferenceAsync()
    {
        try
        {
            var lastWeatherId = await _weatherService.GetLastWeatherIdAsync();

            return Ok
            (
                new LastWeatherReferenceResponse
                (
                    true,
                    new WeatherReferenceDto(lastWeatherId)
                )
            );
        }
        catch (InvalidOperationException)
        {
            return Ok(new LastWeatherReferenceResponse(false, null));
        }
    }

    [HttpPost]
    [Route("api/Weathers/Add/Weather")]
    public async Task AddWeatherAsync([FromBody] AddWeatherRequest weather)
    {
        if (weather.Weather.Temperature == 0)
        {
            throw new ArgumentException();
        }
        await _weatherService.AddNewWeatherAsync(_weatherMapper.Map(weather.Weather));
    }
    
    /// <summary>
    /// Get all existing weathers references
    /// </summary>
    [HttpGet]
    [Route("api/Weathers/References/All")]
    public async Task<ActionResult<AllWeathersReferencesResponse>> GetAllWeathersReferencesAsync()
    {
        return Ok
        (
            new AllWeathersReferencesResponse
            (
                (await _weatherService.GetAllWeathersIdsAsync())
                .Select(wid => new WeatherReferenceDto(wid))
                .ToList()
            )
        );
    }
}