using VideoBench.Domain.Enums;

namespace VideoBench.Application.Dto;

public class SurveyDto
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required DeviceType DeviceType { get; set; }
    public required ICollection<CategoryDto> Categories { get; set; }
    public IEnumerable<FeedbackDto> Feedbacks { get; set; } = new List<FeedbackDto>();
}
