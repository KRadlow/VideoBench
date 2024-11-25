namespace VideoBench.Application.Dto;

public class FeedbackDto
{
    public Guid Id { get; set; }
    public required Guid VideoId { get; set; }
    public required int Bitrate { get; set; }
    public int Score { get; set; }
    public string Source { get; set; } = "";
}
