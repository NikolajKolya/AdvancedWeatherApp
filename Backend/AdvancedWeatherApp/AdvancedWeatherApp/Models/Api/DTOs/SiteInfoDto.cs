using System.Text.Json.Serialization;

namespace AdvancedWeatherApp.Models.Api.DTOs;

/// <summary>
/// Information about site
/// </summary>
public class SiteInfoDto
{
    /// <summary>
    /// Backend version
    /// </summary>
    [JsonPropertyName("backendVersion")]
    public string BackendVersion { get; }

    /// <summary>
    /// Sources repository URL
    /// </summary>
    [JsonPropertyName("sourcesUrl")]
    public string SourcesUrl { get; }

    public SiteInfoDto
    (
        string backendVersion,
        string sourcesUrl
    )
    {
        if (string.IsNullOrWhiteSpace(backendVersion))
        {
            throw new ArgumentException("Backend version must be set!", nameof(backendVersion));
        }
        BackendVersion = backendVersion;

        if (string.IsNullOrWhiteSpace(sourcesUrl))
        {
            throw new ArgumentException("Sources URL must be set!", nameof(sourcesUrl));
        }
        SourcesUrl = sourcesUrl;
    }
}