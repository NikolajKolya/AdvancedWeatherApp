using System.Text.Json.Serialization;
using AdvancedWeatherApp.Models.Api.DTOs;

namespace AdvancedWeatherApp.Models.Api.Responses;

/// <summary>
/// Response with all weathers references
/// </summary>
public class AllWeathersReferencesResponse
{
    /// <summary>
    /// All weathers references
    /// </summary>
    [JsonPropertyName("allWeathersReferences")]
    public IReadOnlyCollection<WeatherReferenceDto> AllWeathersReferences { get; private set; }

    public AllWeathersReferencesResponse
    (
        IReadOnlyCollection<WeatherReferenceDto> allWeathersReferences
    )
    {
        AllWeathersReferences = allWeathersReferences
                                ??
                                throw new ArgumentNullException
                                (
                                    nameof(allWeathersReferences),
                                    "Weather references must not be null!"
                                );

        if (AllWeathersReferences.Any(wr => wr == null))
        {
            throw new ArgumentException("At least one weather reference is null!", nameof(allWeathersReferences));
        }
    }
}