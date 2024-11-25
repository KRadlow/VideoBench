using Microsoft.EntityFrameworkCore;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;
using VideoBench.Infrastructure.Data;

namespace VideoBench.Infrastructure.Repositories;

public class VideoTestRepository(AppDbContext context) : IVideoTestRepository
{
    public async Task<ICollection<VideoTest>> GetUserTestsAsync(Guid userId, int pageNumber, int pageSize)
    {
        var tests = await context.VideoTests
            .Where(x => x.CreatedBy == userId)
            .OrderBy(x => x.EndTime)
            .Include(x=>x.Categories)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return tests;
    }

    public async Task<VideoTest?> GetTestAsync(Guid testId)
    {
        var test = await context.VideoTests
            .Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == testId);

        return test;
    }

    public async Task AddTestAsync(VideoTest videoTest)
    {
        context.VideoTests.Add(videoTest);
        await context.SaveChangesAsync();
    }

    public async Task AddNewSurvey(Survey survey)
    {
        context.Surveys.Add(survey);
        await context.SaveChangesAsync();
    }
}
