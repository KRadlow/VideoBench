using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoBench.Application.Dto;
using VideoBench.Application.Interfaces;

namespace VideoBench.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoTestController(IVideoTestService videoTestService) : ControllerBase
{
    [HttpGet("/{id:guid}")]
    public async Task<ActionResult> GetTestById(Guid id)
    {
        var result = await videoTestService.GetByIdAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetAllTests(int pageNumber, int pageSize)
    {
        var userId = GetUserId();
        if (userId == null)
        {
            return Unauthorized("User does not exist");
        }

        var result = await videoTestService.GetAllAsync(userId.Value, pageNumber, pageSize);

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> CreateNewTests(VideoTestDto videoTest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (videoTest.Categories.Count == 0)
        {
            return BadRequest();
        }

        var userId = GetUserId();
        if (userId == null)
        {
            return Unauthorized("User does not exist");
        }

        var result = await videoTestService.CreateAsync(videoTest, userId.Value);

        return Ok(result);
    }

    private Guid? GetUserId()
    {
        var value = User.FindFirst("sub")?.Value;
        if (value == null)
        {
            return null;
        }

        return Guid.Parse(value);
    }
}
