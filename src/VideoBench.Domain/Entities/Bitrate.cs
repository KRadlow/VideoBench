using System.ComponentModel.DataAnnotations;

namespace VideoBench.Domain.Entities;

public class Bitrate
{
    [Key]
    public Guid Id { get; set; }
    public required int Value { get; set; }
    public required Guid UserId { get; set; }
    public ICollection<VideoTest> Tests { get; set; } = new List<VideoTest>();
}
