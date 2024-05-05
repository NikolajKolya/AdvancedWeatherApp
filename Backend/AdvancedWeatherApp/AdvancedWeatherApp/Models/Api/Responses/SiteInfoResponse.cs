using System.Text.Json.Serialization;
using AdvancedWeatherApp.Models.Api.DTOs;

namespace AdvancedWeatherApp.Models.Api.Responses;

/// <summary>
/// Site info response
/// </summary>
public class SiteInfoResponse
{
    /// <summary>
    /// Site info
    /// </summary>
    [JsonPropertyName("siteInfo")]
    public SiteInfoDto SiteInfo { get; }

    public SiteInfoResponse
    (
        SiteInfoDto siteInfo
    )
    {
        SiteInfo = siteInfo ?? throw new ArgumentNullException(nameof(siteInfo), "Site info must be provided!");
    }
}