using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoBench.Domain.Entities;

[Table("video")]
public class Video
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public required int Bitrate { get; set; }

    public string Link { get; set; } = "";

    public string SourceId { get; set; } = "";

    public int Rate { get; set; }

    public Guid SurveyId { get; set; }

    public Survey Survey { get; set; } = null!;
}
