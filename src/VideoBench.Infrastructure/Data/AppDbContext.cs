using Microsoft.EntityFrameworkCore;
using VideoBench.Domain.Entities;

namespace VideoBench.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Quality> Qualities { get; set; }
    public DbSet<VideoTest> VideoTests { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Video> Videos { get; set; }
}
