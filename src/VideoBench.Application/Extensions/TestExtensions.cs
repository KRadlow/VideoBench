using System.Collections;
using VideoBench.Application.Dto;
using VideoBench.Domain.Entities;

namespace VideoBench.Application.Extensions;

public static class TestExtensions
{
    public static VideoTestDto ToDto(this VideoTest videoTestEntity)
    {
        return new VideoTestDto()
        {
            Id = videoTestEntity.Id,
            StartTime = videoTestEntity.StartTime,
            EndTime = videoTestEntity.EndTime,
            QualityId = videoTestEntity.QualityId,
            Categories = videoTestEntity.Categories.ToDto(),
            Surveys = videoTestEntity.Surveys.Any() ? videoTestEntity.Surveys.ToDto() : null
        };
    }

    public static ICollection<VideoTestDto> ToDto(this ICollection<VideoTest> testEntities)
    {
        return new List<VideoTestDto>(testEntities.Select(ToDto));
    }
}

