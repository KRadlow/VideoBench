using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoBench.Domain.Entities;

[Table("category")]
public class Category
{
    public Category(string name)
    {
        Name = name;
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public ICollection<VideoTest> VideoTests { get; set; } = [];

    public ICollection<Survey> Surveys { get; set; } = [];
}
