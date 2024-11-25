using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoBench.Application.Dto;
using VideoBench.Application.Interfaces;

namespace VideoBench.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class QualityOptionsController(IOptionsService optionsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetQualityOptions()
    {
        var result = await optionsService.GetQualityOptionsAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddNewQualityOption(QualityDto qualityOption)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userId = GetUserId();
        if (userId == null)
        {
            return Unauthorized("User does not exist");
        }

        var result = await optionsService.AddQualityOptionAsync(userId.Value, qualityOption);

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
