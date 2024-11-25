using VideoBench.Domain.Entities;

namespace VideoBench.Domain.Interfaces;

public interface IOptionsRepository
{
    Task AddQualityOptionAsync(Quality qualityOption);
    Task<ICollection<Quality>> GetQualityOptionsAsync();
    Task<Bitrate> GetUserBitrateValueAsync(Guid userId, int value);
    Task<ICollection<Bitrate>> GetUserBitrateValuesAsync(Guid userId);
}
