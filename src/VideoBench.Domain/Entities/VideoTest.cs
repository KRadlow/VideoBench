using System.ComponentModel.DataAnnotations;

namespace VideoBench.Domain.Entities;

public class VideoTest
{
    [Key]
    public Guid Id { get; set; }

    public required Guid CreatedBy { get; set; }

    public required DateTime StartTime { get; set; }

    public required DateTime EndTime { get; set; }

    public int QualityId { get; set; }

    public Quality Quality { get; set; } = null!;

    public ICollection<Category> Categories { get; set; } = new List<Category>();

    public ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
