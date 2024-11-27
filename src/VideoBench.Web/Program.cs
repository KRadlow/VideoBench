using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using VideoBench.Application.Interfaces;
using VideoBench.Application.Mappers;
using VideoBench.Application.Services;
using VideoBench.Domain.Interfaces;
using VideoBench.Infrastructure.Clients;
using VideoBench.Infrastructure.Configuration;
using VideoBench.Infrastructure.Data;
using VideoBench.Infrastructure.Repositories;
using VideoBench.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add serilog services to the container
var logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Configuration
builder.Services.AddOptions<VideoApiConfig>()
    .BindConfiguration(VideoApiConfig.Config)
    .ValidateDataAnnotations()
    .ValidateOnStart();
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<VideoApiConfig>>().Value);

builder.Services.AddOptions<FileServiceConfig>()
    .BindConfiguration(FileServiceConfig.Config)
    .ValidateDataAnnotations()
    .ValidateOnStart();
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<FileServiceConfig>>().Value);

// Add services to the container.
builder.Services.AddCors(options => options.AddPolicy("MyPolicy", policy =>
{
    policy.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGenWithAuth();

builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Develop"));
});

builder.Services.AddSingleton<IVideoApiClient, VideoApiClient>();
builder.Services.AddSingleton<IFileServiceClient, FileServiceClient>();
builder.Services.AddScoped<IVideoTestRepository, VideoTestRepository>();
builder.Services.AddScoped<IVideoTestService, VideoTestService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOptionsRepository, OptionsRepository>();
builder.Services.AddScoped<IOptionsService, OptionsService>();

// Add automapper
builder.Services.AddAutoMapper(typeof(PexelsProfile));

// Configure route paths
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

// Enable cors middleware
app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
