using VideoBench.Application.Dto;
using VideoBench.Application.Utils;

namespace VideoBench.Application.Interfaces;

public interface ICategoryService
{
    Task<Result<IEnumerable<CategoryDto>>> GetAllAsync(Guid userId);
    Task<Result<CategoryDto>> AddAsync(Guid userId, string categoryName );
}
