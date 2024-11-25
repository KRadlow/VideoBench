using VideoBench.Application.Dto;
using VideoBench.Application.Extensions;
using VideoBench.Application.Interfaces;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;

namespace VideoBench.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<IEnumerable<CategoryDto>> GetAllAsync(Guid userId)
    {
        var categories = await categoryRepository.GetUserCategoriesAsync(userId);

        return categories.ToDto();
    }

    public async Task<CategoryDto> AddAsync(Guid userId, string categoryName)
    {
        Category newCategory = new()
        {
            Name = categoryName,
            CreatedBy = userId
        };

        await categoryRepository.AddCategoryAsync(newCategory);

        return newCategory.ToDto();
    }
}
