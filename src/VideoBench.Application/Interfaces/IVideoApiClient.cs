using VideoBench.Application.Dto;
using VideoBench.Domain.Enums;

namespace VideoBench.Application.Interfaces;

public interface IVideoApiClient
{
    Task<IEnumerable<string>> SearchForVideos(IEnumerable<CategoryDto> categories, DeviceType deviceType, string size, int samplesNumber);
}
