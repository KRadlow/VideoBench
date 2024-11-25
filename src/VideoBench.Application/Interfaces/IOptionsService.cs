using VideoBench.Application.Dto;
using VideoBench.Application.Utils;

namespace VideoBench.Application.Interfaces;

public interface IOptionsService
{
    Task<Result<QualityDto>> AddQualityOptionAsync(Guid userId, QualityDto qualityOption);
    Task<Result<IEnumerable<QualityDto>>> GetQualityOptionsAsync();
    Task<Result<IEnumerable<BitrateDto>>> GetUserBitrateValuesAsync(Guid userId);
}
