namespace VideoBench.Application.Interfaces;

public interface IFileServiceClient
{
    Task<string> DownloadAndSaveVideoAsync(string fileName, string bucketName, string url);
}
