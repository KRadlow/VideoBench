using Microsoft.AspNetCore.Mvc;
using VideoBench.Application.Interfaces;

namespace VideoBench.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoController(IVideoService videoService)
{
    [HttpGet]
    public Task<string?> GetVideosList()
    {
        return videoService.GetVideosList("");
    }
}
