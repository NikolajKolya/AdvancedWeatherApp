using AdvancedWeatherApp.DAO.Abstract;
using AdvancedWeatherApp.DAO.Implementations;
using AdvancedWeatherApp.Mappers.Abstract;
using AdvancedWeatherApp.Models;
using AdvancedWeatherApp.Models.Enums;
using AdvancedWeatherApp.Models.Responses;
using AdvancedWeatherApp.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IReadOnlyCollection<Weather>> GetWeather(WeatherTypeEnum weatherTypeEnum)
    {
        DateOnly dateTime;

        switch (weatherTypeEnum)
        {
            case WeatherTypeEnum.DailyWeather:
                dateTime = DateOnly.FromDateTime(DateTime.UtcNow);
                return new List<Weather>(){ _weatherMapper.Map(await _weatherDao.GetWeatherOnDateTime(dateTime))};
                break;
            case WeatherTypeEnum.WeatherTomorrow:
                dateTime = DateOnly.FromDateTime(DateTime.UtcNow).AddDays(1);
                return new List<Weather>(){ _weatherMapper.Map(await _weatherDao.GetWeatherOnDateTime(dateTime))};
                break;
            case WeatherTypeEnum.WeeklyWeather:
                var weathers = new List<Weather>();
                for (int i = 0; i < 7; i++)
                {
                    dateTime = DateOnly.FromDateTime(DateTime.UtcNow ).AddDays(i);
                    weathers.Add(_weatherMapper.Map(await _weatherDao.GetWeatherOnDateTime(dateTime)));
                } 
                break;/*
            case WeatherTypeEnum.LastWeather:
                */
        }
        return new List<Weather>()
        {
            new Weather()
            {
                Id = new Guid(),
                Humidity = 40.53,
                Pressure = 1325,
                Temperature = 31
            },
            new Weather()
            {
                Id = new Guid(),
                Humidity = 42.53,
                Pressure = 1275,
                Temperature = 27
            }
        };
    }
}