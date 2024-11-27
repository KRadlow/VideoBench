using Newtonsoft.Json;

namespace VideoBench.Infrastructure.Configuration;

public class FileServiceConfig
{
    public const string Config = "Minio";

    [JsonRequired]
    public required string Endpoint { get; set; }

    [JsonRequired]
    public required string AccessKey { get; set; }

    [JsonRequired]
    public required string SecretKey { get; set; }
}
