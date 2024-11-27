using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using VideoBench.Application.Interfaces;
using VideoBench.Infrastructure.Configuration;

namespace VideoBench.Infrastructure.Clients;

public class FileServiceClient(FileServiceConfig config) : IFileServiceClient
{
    private const string VIDEO_CONTENT_TYPE = "video/mp4";
    private readonly HttpClient _httpClient = new();
    private readonly IMinioClient _minio = new MinioClient()
        .WithEndpoint(config.Endpoint)
        .WithCredentials(config.AccessKey, config.SecretKey)
        .Build();

    public async Task<string> DownloadAndSaveVideoAsync(string fileName, string bucketName, string url)
    {
        // Make a bucket on the server, if not already present.
        var beArgs = new BucketExistsArgs().WithBucket(bucketName);
        bool found = await _minio.BucketExistsAsync(beArgs).ConfigureAwait(false);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs().WithBucket(bucketName);
            await _minio.MakeBucketAsync(mbArgs).ConfigureAwait(false);
        }

        // Download video
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var video = await response.Content.ReadAsStreamAsync();

        // Upload video
        PutObjectArgs poa = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(fileName)
            .WithStreamData(video)
            .WithObjectSize(video.Length)
            .WithContentType(VIDEO_CONTENT_TYPE);

        await _minio.PutObjectAsync(poa);

        StatObjectArgs stat = new StatObjectArgs()
            .WithBucket(bucketName)
            .WithObject(fileName);

        ObjectStat objectStat = await _minio.StatObjectAsync(stat);

        return objectStat.ObjectName;
    }
}
