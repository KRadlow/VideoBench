using System.ComponentModel.DataAnnotations;

namespace VideoBench.Domain.Entities;

public class VideoTest
{
    [Key]
    public Guid Id { get; set; }

    public required Guid CreatedBy { get; set; }

    public required DateTime StartTime { get; set; }

    public required DateTime EndTime { get; set; }

    public required int SamplesNumber { get; set; }

    public int QualityId { get; set; }

    public Quality Quality { get; set; } = null!;

    public required ICollection<Bitrate> BitrateValues { get; set; }

    public required ICollection<Category> Categories { get; set; }

    public ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
