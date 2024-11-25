using VideoBench.Application.Dto;

namespace VideoBench.Application.Interfaces;

public interface IOptionsService
{
    Task<QualityDto> AddQualityOptionAsync(Guid userId, QualityDto qualityOption);
    Task<IEnumerable<QualityDto>> GetQualityOptionsAsync();
}
