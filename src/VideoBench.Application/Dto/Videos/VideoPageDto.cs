namespace VideoBench.Application.Dto;

public class VideoPageDto
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int TotalResults { get; set; }
    public string? NextPage { get; set; }
    public IEnumerable<VideoDto>? Videos { get; set; }
}
