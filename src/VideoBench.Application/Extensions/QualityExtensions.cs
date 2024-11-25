using VideoBench.Application.Dto;
using VideoBench.Domain.Entities;

namespace VideoBench.Application.Extensions;

public static class QualityExtensions
{
    public static QualityDto ToDto(this Quality qualityEntity)
    {
        return new QualityDto()
        {
            Id = qualityEntity.Id,
            Name = qualityEntity.Name,
            Width = qualityEntity.Width,
            Height = qualityEntity.Height
        };
    }

    public static ICollection<QualityDto> ToDto(this ICollection<Quality> qualityOptions)
    {
        return new List<QualityDto>(qualityOptions.Select(ToDto));
    }
}
