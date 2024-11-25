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

    public async Task<Bitrate> GetUserBitrateValueAsync(Guid userId, int value)
    {
        var bitrate = await context.BitrateValues
            .Where(x => x.Value == value)
            .FirstOrDefaultAsync(x => x.UserId == userId);

        if (bitrate != null)
            return bitrate;

        Bitrate newBitrateValue = new()
        {
            Value = value,
            UserId = userId
        };
        context.BitrateValues.Add(newBitrateValue);
        await context.SaveChangesAsync();

        return newBitrateValue;
    }

    public async Task<ICollection<Bitrate>> GetUserBitrateValuesAsync(Guid userId)
    {
        return await context.BitrateValues
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}
