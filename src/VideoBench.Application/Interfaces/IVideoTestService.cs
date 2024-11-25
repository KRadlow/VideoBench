using VideoBench.Application.Dto;

namespace VideoBench.Application.Interfaces;

public interface IVideoTestService
{
    Task<IEnumerable<VideoTestDto>> GetAllAsync(Guid userId, int pageNumber, int pageSize);
    Task<VideoTestDto?> GetByIdAsync(Guid testId);
    Task<VideoTestDto> CreateAsync(VideoTestDto videoTest, Guid userId);
}
