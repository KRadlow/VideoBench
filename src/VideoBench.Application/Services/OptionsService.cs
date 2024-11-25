using VideoBench.Application.Dto;
using VideoBench.Application.Extensions;
using VideoBench.Application.Interfaces;
using VideoBench.Application.Utils;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;

namespace VideoBench.Application.Services;

public class OptionsService(IOptionsRepository optionsRepository) : IOptionsService
{
    public async Task<Result<QualityDto>> AddQualityOptionAsync(Guid userId, QualityDto qualityOption)
    {
        Quality newQualityOption = new()
        {
            Name = qualityOption.Name,
            Width = qualityOption.Width,
            Height = qualityOption.Height,
            CreatedBy = userId
        };

        await optionsRepository.AddQualityOptionAsync(newQualityOption);

        return Result<QualityDto>.Success(newQualityOption.ToDto());
    }

    public async Task<Result<IEnumerable<QualityDto>>> GetQualityOptionsAsync()
    {
        var qualityOptions = await optionsRepository.GetQualityOptionsAsync();

        if (qualityOptions.Count == 0)
        {
            return Result<IEnumerable<QualityDto>>.Failure("No quality options found.");
        }

        return Result<IEnumerable<QualityDto>>.Success(qualityOptions.ToDto());
    }

    public async Task<Result<IEnumerable<BitrateDto>>> GetUserBitrateValuesAsync(Guid userId)
    {
        var bitrateValues = await optionsRepository.GetUserBitrateValuesAsync(userId);

        if (bitrateValues.Count == 0)
        {
            return Result<IEnumerable<BitrateDto>>.Failure("No Bitrate values found.");
        }

        return Result<IEnumerable<BitrateDto>>.Success(bitrateValues.ToDto());
    }
}
