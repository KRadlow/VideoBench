namespace VideoBench.Application.Dto;

public class VideoFileDto
{
    public int Id { get; set; }
    public string? Quality { get; set; }
    public string? FileType { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string? Link { get; set; }
}
