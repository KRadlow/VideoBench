using VideoBench.Application.Dto;
using VideoBench.Domain.Entities;

namespace VideoBench.Application.Extensions;

public static class BitrateExtensions
{
    public static BitrateDto ToDto(this Bitrate bitrateEntity)
    {
        return new BitrateDto()
        {
            Value = bitrateEntity.Value
        };
    }

    public static ICollection<BitrateDto> ToDto(this ICollection<Bitrate> bitrateEntities)
    {
        return new List<BitrateDto>(bitrateEntities.Select(ToDto));
    }
}
