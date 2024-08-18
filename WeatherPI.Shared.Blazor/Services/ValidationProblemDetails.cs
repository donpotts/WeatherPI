using System.Text.Json.Serialization;

namespace WeatherPI.Shared.Blazor.Services;

internal class ValidationProblemDetails : ProblemDetails
{
    [JsonPropertyName("errors")]
    public Dictionary<string, List<string>>? Errors { get; set; }
}
