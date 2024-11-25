using Microsoft.EntityFrameworkCore;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;
using VideoBench.Infrastructure.Data;

namespace VideoBench.Infrastructure.Repositories;

public class OptionsRepository(AppDbContext context) : IOptionsRepository
{
    public async Task AddQualityOptionAsync(Quality qualityOption)
    {
        context.Qualities.Add(qualityOption);
        await context.SaveChangesAsync();
    }

    public async Task<ICollection<Quality>> GetQualityOptionsAsync()
    {
        return await context.Qualities.ToListAsync();
    }
}
