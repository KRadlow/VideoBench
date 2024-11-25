using System.Collections;
using VideoBench.Application.Dto;
using VideoBench.Domain.Entities;

namespace VideoBench.Application.Extensions;

public static class SurveyExtensions
{
    public static SurveyDto ToDto(this Survey surveyEntity)
    {
        return new SurveyDto()
        {
            Id = surveyEntity.Id,
            UserName = surveyEntity.Username,
            DeviceType = surveyEntity.DeviceType,
            Categories = surveyEntity.Categories.ToDto(),
            Feedbacks = surveyEntity.Feedbacks.ToDto()
        };
    }

    public static ICollection<SurveyDto>? ToDto(this ICollection<Survey> surveyEntities)
    {
        return new List<SurveyDto>(surveyEntities.Select(ToDto));
    }
}
