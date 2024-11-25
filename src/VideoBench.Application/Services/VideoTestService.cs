using VideoBench.Application.Dto;
using VideoBench.Application.Extensions;
using VideoBench.Application.Interfaces;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;

namespace VideoBench.Application.Services;

public class VideoTestService(IVideoTestRepository videoTestRepository, ICategoryRepository categoryRepository) : IVideoTestService
{
    public async Task<IEnumerable<VideoTestDto>> GetAllAsync(Guid userId, int pageNumber, int pageSize)
    {
        var tests = await videoTestRepository.GetUserTestsAsync(userId, pageNumber, pageSize);

        return tests.ToDto();
    }

    public async Task<VideoTestDto?> GetByIdAsync(Guid testId)
    {
        var test = await videoTestRepository.GetTestAsync(testId);

        return test?.ToDto();
    }

    public async Task<VideoTestDto> CreateAsync(VideoTestDto videoTest, Guid userId)
    {
        var categories = new List<Category>();
        foreach (var categoryDto in videoTest.Categories)
        {
            var categoryEntity = await categoryRepository.GetCategoryByIdAsync(categoryDto.Id);

            if (categoryEntity != null)
            {
                categories.Add(categoryEntity);
            }
        }

        VideoTest newVideoTest = new()
        {
            CreatedBy = userId,
            StartTime = videoTest.StartTime,
            EndTime = videoTest.EndTime,
            Categories = categories,
            QualityId = videoTest.QualityId
        };

        await videoTestRepository.AddTestAsync(newVideoTest);

        return newVideoTest.ToDto();
    }
}
