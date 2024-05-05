using AdvancedWeatherApp.Models.Api.DTOs;
using AdvancedWeatherApp.Models.Api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedWeatherApp.Controllers;

/// <summary>
/// Site info controller
/// </summary>
[ApiController]
public class SiteInfoController : ControllerBase
{
    /// <summary>
    /// Get site info
    /// </summary>
    [Route("api/Site/Info")]
    [HttpGet]
    public async Task<ActionResult<SiteInfoResponse>> GetSiteInfoAsync()
    {
        return Ok
        (
            new SiteInfoResponse
            (
                new SiteInfoDto
                (
                    "Погода Бэкенд v. 1",
                    "https://github.com/NikolajKolya/AdvancedWeatherApp"
                )
            )
        );
    }
}