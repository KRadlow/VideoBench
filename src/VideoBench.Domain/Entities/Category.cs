using System.ComponentModel.DataAnnotations;

namespace VideoBench.Domain.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required Guid CreatedBy { get; set; }

    public ICollection<VideoTest> Tests { get; set; } = new List<VideoTest>();

    public ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
