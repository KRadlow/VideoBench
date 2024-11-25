using VideoBench.Application.Dto;
using VideoBench.Application.Extensions;
using VideoBench.Application.Interfaces;
using VideoBench.Application.Utils;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;

namespace VideoBench.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<Result<IEnumerable<CategoryDto>>> GetAllAsync(Guid userId)
    {
        var categories = await categoryRepository.GetUserCategoriesAsync(userId);

        if (categories.Count == 0)
        {
            return Result<IEnumerable<CategoryDto>>.Failure("Categories not found");
        }
        
        return Result<IEnumerable<CategoryDto>>.Success(categories.ToDto());
    }

    public async Task<Result<CategoryDto>> AddAsync(Guid userId, string categoryName)
    {
        Category newCategory = new()
        {
            Name = categoryName,
            CreatedBy = userId
        };

        await categoryRepository.AddCategoryAsync(newCategory);

        return Result<CategoryDto>.Success(newCategory.ToDto());
    }
}
