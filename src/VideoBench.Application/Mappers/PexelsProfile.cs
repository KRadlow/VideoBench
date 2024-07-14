using AutoMapper;
using PexelsDotNetSDK.Models;
using VideoBench.Application.Dto;
using VideoPage = PexelsDotNetSDK.Models.VideoPage;

namespace VideoBench.Application.Mappers;

public class PexelsProfile : Profile
{
    public PexelsProfile()
    {
        CreateMap<VideoPage, VideoPageDto>()
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.page))
            .ForMember(dest => dest.PerPage, opt => opt.MapFrom(src => src.perPage))
            .ForMember(dest => dest.TotalResults, opt => opt.MapFrom(src => src.totalResults))
            .ForMember(dest => dest.NextPage, opt => opt.MapFrom(src => src.nextPage))
            .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.videos));

        CreateMap<Video, VideoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.width))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.height))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.url))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.image))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.duration))
            .ForMember(dest => dest.VideoFiles, opt => opt.MapFrom(src => src.videoFiles));

        CreateMap<VideoFile, VideoFileDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Quality, opt => opt.MapFrom(src => src.quality))
            .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.fileType))
            .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.width))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.height))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.link));
    }
}
