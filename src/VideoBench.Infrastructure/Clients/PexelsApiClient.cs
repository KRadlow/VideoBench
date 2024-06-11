using System.Text.Json;
using PexelsDotNetSDK.Api;
using VideoBench.Application.Interfaces;
using VideoBench.Infrastructure.Configuration;

namespace VideoBench.Infrastructure.Clients;

public class PexelsApiClient(VideoApiConfig config) : IVideoApiClient
{
    public async Task<string?> SearchForVideos(string query)
    {
        var pexelsClient = new PexelsClient(config.ApiKey);

        var result =  await pexelsClient.SearchVideosAsync(query);

        return JsonSerializer.Serialize(result);
    }
}
