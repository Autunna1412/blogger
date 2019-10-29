using Blogger.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Blogger.Infrastructure.Persistence.Models;
using System.Linq;

namespace Blogger.Core.Application.Mapper
{
    public class ArticleMappingProfile : MappingProfileBase<Article, ArticleDto>
    {
        public ArticleMappingProfile()
        {
            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Hashtags, opt => opt.MapFrom(
                    (src, dest) => (dest.Hashtags = src.Hashtags.Split(';').Select(s => s).ToList())
                    ))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(
                    (src, dest) => (dest.ImageUrl = src.ImageUrl.Split(';').Select(s => s).ToList())
                ));

            CreateMap<ArticleDto, Article>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Hashtags, opt => opt.MapFrom(src =>
                    (src.Hashtags == null || !src.Hashtags.Any())
                        ? string.Empty
                        : String.Join(';', src.Hashtags.Select(x => x))
                ))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src =>
                    (src.ImageUrl == null || !src.ImageUrl.Any())
                        ? string.Empty
                        : String.Join(';', src.Hashtags.Select(x => x))
                ));
        }
    }
}
