using Microsoft.Extensions.Options;
using VideoBench.Application.Interfaces;
using VideoBench.Application.Services;
using VideoBench.Infrastructure.Clients;
using VideoBench.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Services.AddOptions<VideoApiConfig>()
    .BindConfiguration(VideoApiConfig.ApiConfig)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<VideoApiConfig>>().Value);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IVideoApiClient, PexelsApiClient>();
builder.Services.AddSingleton<IVideoService, VideoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
