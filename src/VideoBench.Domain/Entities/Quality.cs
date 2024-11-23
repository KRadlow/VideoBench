using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoBench.Domain.Entities;

[Table("quality")]
public class Quality
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required int Width { get; set; }

    [Required]
    public required int Height { get; set; }

    public ICollection<VideoTest> VideoTests { get; set; } = [];
}
