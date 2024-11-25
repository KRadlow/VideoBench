using Microsoft.EntityFrameworkCore;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;
using VideoBench.Infrastructure.Data;

namespace VideoBench.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<ICollection<Category>> GetUserCategoriesAsync(Guid userId)
    {
        return await context.Categories
            .Where(x => x.CreatedBy == userId)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
    {
        return await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Category>> GetCategoriesByIdsAsync(List<Guid> categoryIds)
    {
        return await context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
    }

    public async Task AddCategoryAsync(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
    }
}
