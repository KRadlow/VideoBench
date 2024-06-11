namespace VideoBench.Application.Interfaces;

public interface IVideoService
{
    Task<string?> GetVideosList(string query);
}
