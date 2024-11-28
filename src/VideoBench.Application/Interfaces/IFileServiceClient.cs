namespace VideoBench.Application.Interfaces;

public interface IFileServiceClient
{
    Task<string> DownloadAndSaveVideoAsync(string fileName, string bucketName, string url);
    Task<string?> GetVideoLinkAsync(string fileName, string bucketName, int expiresInSeconds);
}
