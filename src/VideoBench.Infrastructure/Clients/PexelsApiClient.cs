using AutoMapper;
using PexelsDotNetSDK.Api;
using VideoBench.Application.Dto;
using VideoBench.Application.Interfaces;
using VideoBench.Infrastructure.Configuration;
using PexelsDotNetSDK.Models;


namespace VideoBench.Infrastructure.Clients;

public class PexelsApiClient(VideoApiConfig config, IMapper mapper) : IVideoApiClient
{
    public async Task<VideoPageDto?> SearchForVideos(string query)
    {
        var pexelsClient = new PexelsClient(config.ApiKey);

        var searchResult =  await pexelsClient.SearchVideosAsync(query);

        VideoPageDto result = mapper.Map<VideoPage, VideoPageDto>(searchResult);

        return result;
    }
}
