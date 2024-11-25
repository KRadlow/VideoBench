using VideoBench.Domain.Entities;

namespace VideoBench.Domain.Interfaces;

public interface IOptionsRepository
{
    Task AddQualityOptionAsync(Quality qualityOption);
    Task<ICollection<Quality>> GetQualityOptionsAsync();
}
