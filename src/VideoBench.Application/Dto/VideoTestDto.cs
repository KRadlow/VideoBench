namespace VideoBench.Application.Dto;

public class VideoTestDto
{
    public Guid Id { get; set; }
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }
    public required int QualityId { get; set; }
    public required ICollection<CategoryDto> Categories { get; set; }
    public IEnumerable<SurveyDto>? Surveys { get; set; } = new List<SurveyDto>();
}
