using System.Text.Json.Serialization;

namespace VideoBench.Infrastructure.Configuration;

public class VideoApiConfig
{
    public const string ApiConfig = "VideoApi";

    [JsonRequired]
    public required string ApiKey { get; set; }
}
