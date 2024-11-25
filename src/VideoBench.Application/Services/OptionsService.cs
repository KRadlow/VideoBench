using VideoBench.Application.Dto;
using VideoBench.Application.Extensions;
using VideoBench.Application.Interfaces;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;

namespace VideoBench.Application.Services;

public class OptionsService(IOptionsRepository optionsRepository) : IOptionsService
{
    public async Task<QualityDto> AddQualityOptionAsync(Guid userId, QualityDto qualityOption)
    {
        Quality newQualityOption = new()
        {
            Name = qualityOption.Name,
            Width = qualityOption.Width,
            Height = qualityOption.Height,
            CreatedBy = userId
        };

        await optionsRepository.AddQualityOptionAsync(newQualityOption);

        return newQualityOption.ToDto();
    }

    public async Task<IEnumerable<QualityDto>> GetQualityOptionsAsync()
    {
        var qualityOptions = await optionsRepository.GetQualityOptionsAsync();

        return qualityOptions.ToDto();
    }
}
