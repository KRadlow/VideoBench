using System.ComponentModel.DataAnnotations;
using VideoBench.Domain.Enums;

namespace VideoBench.Domain.Entities;

public class Survey
{
    [Key]
    public Guid Id { get; set; }

    public required string Username { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public required DeviceType DeviceType { get; set; }

    public required ICollection<Category> Categories { get; set; }

    public required ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public required Guid TestId { get; set; }

    public VideoTest Test { get; set; } = null!;
}
