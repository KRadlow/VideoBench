namespace VideoBench.Application.Dto;

public class VideoDto
{
    public int Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string? Url { get; set; }
    public string? Image { get; set; }
    public int Duration { get; set; }
    public List<VideoFileDto>? VideoFiles { get; set; }
}
