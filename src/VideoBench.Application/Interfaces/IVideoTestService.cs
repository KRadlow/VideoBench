using VideoBench.Application.Dto;
using VideoBench.Application.Utils;

namespace VideoBench.Application.Interfaces;

public interface IVideoTestService
{
    Task<Result<IEnumerable<VideoTestDto>>> GetAllAsync(Guid userId, int pageNumber, int pageSize);
    Task<Result<VideoTestDto>> GetByIdAsync(Guid testId);
    Task<Result<VideoTestDto>> CreateAsync(VideoTestDto videoTest, Guid userId);
    Task<Result<SurveyDto>> AddNewSurveyAsync(Guid testId, SurveyDto survey);
}
