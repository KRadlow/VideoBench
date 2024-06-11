namespace VideoBench.Application.Interfaces;

public interface IVideoApiClient
{
    Task<string?> SearchForVideos(string query);
}
