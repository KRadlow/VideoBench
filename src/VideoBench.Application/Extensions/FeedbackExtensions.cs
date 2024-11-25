using System.Collections;
using VideoBench.Application.Dto;
using VideoBench.Domain.Entities;

namespace VideoBench.Application.Extensions;

public static class FeedbackExtensions
{
    public static FeedbackDto ToDto(this Feedback feedbackEntity)
    {
        return new FeedbackDto()
        {
            Id = feedbackEntity.Id,
            VideoId = feedbackEntity.VideoId,
            Bitrate = feedbackEntity.Bitrate,
            Score = feedbackEntity.Score,
            Source = feedbackEntity.Source
        };
    }

    public static ICollection<FeedbackDto> ToDto(this ICollection<Feedback> feedbackEntities)
    {
        return new List<FeedbackDto>(feedbackEntities.Select(ToDto));
    }
}
