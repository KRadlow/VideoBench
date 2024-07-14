using VideoBench.Application.Dto;

namespace VideoBench.Application.Interfaces;

public interface IVideoApiClient
{
    Task<VideoPageDto?> SearchForVideos(string query);
}
