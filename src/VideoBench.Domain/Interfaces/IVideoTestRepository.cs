using VideoBench.Domain.Entities;

namespace VideoBench.Domain.Interfaces;

public interface IVideoTestRepository
{
    Task<ICollection<VideoTest>> GetUserTestsAsync(Guid userId, int pageNumber, int pageSize);
    Task<VideoTest?> GetTestAsync(Guid testId);
    Task AddTestAsync(VideoTest videoTest);
    Task AddNewSurvey(Survey survey);
    Task<ICollection<Survey>> GetTestSurveysAsync(Guid testId, int? pageNumber, int? pageSize);
}
