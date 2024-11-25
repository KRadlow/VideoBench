using VideoBench.Domain.Entities;

namespace VideoBench.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<ICollection<Category>> GetUserCategoriesAsync(Guid userId);
    Task<Category?> GetCategoryByIdAsync(Guid id);
    Task AddCategoryAsync(Category category);
}
