using System.Text.Json.Serialization;

namespace AdvancedWeatherApp.Models.Api.Requests;

/// <summary>
/// Request to get some weathers
/// </summary>
public class GetWeathersByIdsRequest
{
    /// <summary>
    /// Weathers IDs
    /// </summary>
    [JsonPropertyName("weathersIds")]
    public IList<Guid> RequestedWeathersIds { get; set; }
}