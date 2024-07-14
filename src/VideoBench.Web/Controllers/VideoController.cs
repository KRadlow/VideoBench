using Microsoft.AspNetCore.Mvc;
using VideoBench.Application.Dto;
using VideoBench.Application.Interfaces;

namespace VideoBench.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoController(IVideoService videoService)
{
    [HttpGet]
    public Task<VideoPageDto?> GetVideosList()
    {
        return videoService.GetVideosList("");
    }
}
