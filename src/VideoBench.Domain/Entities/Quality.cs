using System.ComponentModel.DataAnnotations;

namespace VideoBench.Domain.Entities;

public class Quality
{
    [Key]
    public int Id { get; set; }

    public required Guid CreatedBy { get; set; }

    public required string Name { get; set; }

    public required int Width { get; set; }

    public required int Height { get; set; }

    public ICollection<VideoTest> Tests { get; set; } = new List<VideoTest>();
}
