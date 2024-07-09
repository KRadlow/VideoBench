using VideoBench.Application.Dto;
using VideoBench.Application.Interfaces;

namespace VideoBench.Application.Services;

public class VideoService(IVideoApiClient videoApiClient) : IVideoService
{
    public Task<VideoPageDto?> GetVideosList(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return videoApiClient.SearchForVideos("nature");
        }

        return videoApiClient.SearchForVideos(query);
    }
}
