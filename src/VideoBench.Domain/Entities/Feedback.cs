using System.ComponentModel.DataAnnotations;

namespace VideoBench.Domain.Entities;

public class Feedback
{
    [Key]
    public Guid Id { get; set; }

    public required Guid VideoId { get; set; }

    public required int Bitrate { get; set; }

    public int Score { get; set; }

    public DateTime RatedAt { get; set; }

    public string Source { get; set; } = "";

    public Guid SurveyId { get; set; }

    public Survey Survey { get; set; } = null!;
}
