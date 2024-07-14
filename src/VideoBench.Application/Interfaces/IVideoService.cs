using VideoBench.Application.Dto;

namespace VideoBench.Application.Interfaces;

public interface IVideoService
{
    Task<VideoPageDto?> GetVideosList(string query);
}
