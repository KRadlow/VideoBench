using VideoBench.Application.Dto;
using VideoBench.Domain.Entities;

namespace VideoBench.Application.Extensions;

public static class CategoryExtensions
{
    public static CategoryDto ToDto(this Category categoryEntity)
    {
        return new CategoryDto()
        {
            Id = categoryEntity.Id,
            Name = categoryEntity.Name
        };
    }

    public static ICollection<CategoryDto> ToDto(this ICollection<Category> categories)
    {
        return new List<CategoryDto>(categories.Select(ToDto));
    }
}
