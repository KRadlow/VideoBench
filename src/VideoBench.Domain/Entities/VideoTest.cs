using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoBench.Domain.Entities;

[Table("video_test")]
public class VideoTest
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public required string UserId { get; set; }

    [Required]
    public required DateTime StartTime { get; set; }

    [Required]
    public required DateTime EndTime { get; set; }

    [Required]
    public int QualityId { get; set; }

    [Required]
    public Quality Quality { get; set; } = null!;

    [Required]
    public required ICollection<Category> Categories { get; set; }

    [Required]
    public required ICollection<Survey> Surveys { get; set; }
}
