using AutoMapper;
using PexelsDotNetSDK.Api;
using PexelsDotNetSDK.Models;
using VideoBench.Application.Dto;
using VideoBench.Application.Interfaces;
using VideoBench.Domain.Enums;
using VideoBench.Infrastructure.Configuration;

namespace VideoBench.Infrastructure.Clients;

public class VideoApiClient(VideoApiConfig config, IMapper mapper) : IVideoApiClient
{
    private readonly PexelsClient _client = new PexelsClient(config.ApiKey);

    private async Task<VideoPageDto> SearchForVideos(string query, string orientation, string size, int page = 1, int pageSize = 10)
    {
        var searchResult =  await _client.SearchVideosAsync(query, orientation, size, "", page, pageSize);

        var result = mapper.Map<VideoPage, VideoPageDto>(searchResult);

        return result;
    }

    public async Task<IEnumerable<string>> SearchForVideos(IEnumerable<CategoryDto> categories, DeviceType deviceType, string size = "medium", int samplesNumber = 10)
    {
        var categoryDtos = categories.ToList();
        var videosPerCategory = (int)Math.Ceiling(samplesNumber / (double)categoryDtos.Count);

        var page = 1;
        List<string> links = [];
        foreach (var categoryDto in categoryDtos)
        {
            var orientation = deviceType == DeviceType.Desktop ? "landscape" : "portrait";
            var response = await SearchForVideos(categoryDto.Name, orientation, size, page, videosPerCategory);
            if (response.Videos != null)
            {
                links.AddRange(response.Videos.Select(video => video.VideoFiles?.First().Link).OfType<string>());
            }
            page++;
        }

        return links.Take(samplesNumber);
    }
}
