using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoBench.Domain.Enums;

namespace VideoBench.Domain.Entities;

[Table("survey")]
public class Survey
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public required string Username { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public required DeviceType DeviceType { get; set; }

    [Required]
    public required ICollection<Category> Categories { get; set; }

    [Required]
    public required ICollection<Video> Videos { get; set; }

    [Required]
    public Guid VideoTestId { get; set; }

    [Required]
    public VideoTest VideoTest { get; set; } = null!;
}
