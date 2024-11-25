using VideoBench.Domain.Entities;

namespace VideoBench.Domain.Interfaces;

public interface IVideoTestRepository
{
    Task<ICollection<VideoTest>> GetUserTestsAsync(Guid userId, int pageNumber, int pageSize);
    Task<VideoTest?> GetTestAsync(Guid testId);
    Task AddTestAsync(VideoTest videoTest);
}
