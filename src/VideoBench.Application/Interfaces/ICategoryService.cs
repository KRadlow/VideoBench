using VideoBench.Application.Dto;

namespace VideoBench.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync(Guid userId);
    Task<CategoryDto> AddAsync(Guid userId, string categoryName );
}
