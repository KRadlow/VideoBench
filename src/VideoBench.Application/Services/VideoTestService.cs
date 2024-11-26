using VideoBench.Application.Dto;
using VideoBench.Application.Extensions;
using VideoBench.Application.Interfaces;
using VideoBench.Application.Utils;
using VideoBench.Domain.Entities;
using VideoBench.Domain.Interfaces;

namespace VideoBench.Application.Services;

public class VideoTestService(IVideoTestRepository videoTestRepository, ICategoryRepository categoryRepository, IOptionsRepository optionsRepository) : IVideoTestService
{
    public async Task<Result<IEnumerable<VideoTestDto>>> GetAllAsync(Guid userId, int pageNumber, int pageSize)
    {
        var tests = await videoTestRepository.GetUserTestsAsync(userId, pageNumber, pageSize);

        if (tests.Count == 0)
        {
            return Result<IEnumerable<VideoTestDto>>.Failure("No tests found");
        }

        foreach (var test in tests)
        {
            var testSurveys = await videoTestRepository.GetTestSurveysAsync(test.Id, null, null);
            if (testSurveys.Count != 0)
            {
                test.Surveys = testSurveys;
            }
        }

        return Result<IEnumerable<VideoTestDto>>.Success(tests.ToDto());
    }

    public async Task<Result<VideoTestDto>> GetByIdAsync(Guid testId)
    {
        var test = await videoTestRepository.GetTestAsync(testId);

        if (test == null)
        {
            return Result<VideoTestDto>.Failure("Test not found");
        }

        var testSurveys = await videoTestRepository.GetTestSurveysAsync(test.Id, null, null);
        if (testSurveys.Count != 0)
        {
            test.Surveys = testSurveys;
        }

        return Result<VideoTestDto>.Success(test.ToDto());
    }

    public async Task<Result<VideoTestDto>> CreateAsync(VideoTestDto videoTest, Guid userId)
    {
        // Categories select
        var categories = new List<Category>();
        foreach (var categoryDto in videoTest.Categories)
        {
            var categoryEntity = await categoryRepository.GetCategoryByIdAsync(categoryDto.Id);

            if (categoryEntity != null)
            {
                categories.Add(categoryEntity);
            }
        }

        if (categories.Count == 0)
        {
            return Result<VideoTestDto>.Failure("Categories not found");
        }

        // Bitrate select
        var bitrateValues = new List<Bitrate>();
        foreach (var bitrateDto in videoTest.BitrateValues)
        {
            var bitrateEntity = await optionsRepository.GetUserBitrateValueAsync(userId, bitrateDto.Value);
            bitrateValues.Add(bitrateEntity);
        }

        if (bitrateValues.Count == 0)
        {
            return Result<VideoTestDto>.Failure("Bitrate values not found");
        }

        // Add new test
        VideoTest newVideoTest = new()
        {
            CreatedBy = userId,
            StartTime = videoTest.StartTime,
            EndTime = videoTest.EndTime,
            SamplesNumber = videoTest.SamplesNumber,
            BitrateValues = bitrateValues,
            Categories = categories,
            QualityId = videoTest.QualityId
        };

        await videoTestRepository.AddTestAsync(newVideoTest);

        return Result<VideoTestDto>.Success(newVideoTest.ToDto());
    }

    public async Task<Result<SurveyDto>> AddNewSurveyAsync(Guid testId, SurveyDto survey)
    {
        var test = await GetByIdAsync(testId);
        if (!test.IsSuccess || test.Value == null)
        {
            return Result<SurveyDto>.Failure("Test not found");
        }

        // Categories select
        var categories = new List<Category>();
        foreach (var categoryDto in survey.Categories)
        {
            var categoryEntity = await categoryRepository.GetCategoryByIdAsync(categoryDto.Id);

            if (categoryEntity != null)
            {
                categories.Add(categoryEntity);
            }
        }

        if (categories.Count == 0)
        {
            return Result<SurveyDto>.Failure("Test categories not found");
        }

        // Create survey
        List<Feedback> feedbacks = new();

        var sampleNumber = 0;
        while (sampleNumber < test.Value.SamplesNumber)
        {
            feedbacks.AddRange(test.Value.BitrateValues.Select(bitrate => new Feedback()
            {
                VideoId = new Guid(), // placeholder
                Bitrate = bitrate.Value,
            }));

            sampleNumber++;
        }

        Survey newSurvey = new()
        {
            Username = survey.UserName,
            DeviceType = survey.DeviceType,
            Categories = categories,
            TestId = testId,
            Feedbacks = feedbacks
        };

        await videoTestRepository.AddNewSurvey(newSurvey);

        return Result<SurveyDto>.Success(newSurvey.ToDto());
    }
}
