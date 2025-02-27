using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoBench.Application.Interfaces;

namespace VideoBench.Web.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetCategories()
    {
        var userId = GetUserId();
        if (userId == null)
        {
            return Unauthorized("User does not exist");
        }

        var result = await categoryService.GetAllAsync(userId.Value);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<ActionResult> AddNewCategory(string categoryName)
    {
        var userId = GetUserId();
        if (userId == null)
        {
            return Unauthorized("User does not exist");
        }

        var result = await categoryService.AddAsync(userId.Value, categoryName);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(result.Value);
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
