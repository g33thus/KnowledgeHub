using AutoMapper;
using Employee_Hub.DTOs;
using Employee_Hub.Models;
using Employee_Hub.Models.NewsAPI;

namespace Employee_Hub
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NewsApiResponse, ArticleDto>().ReverseMap();
            CreateMap<ArticleDto, Article>()
                .ForMember(dest => dest.Snippet, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.UrlToImage)).ReverseMap(); 
            this.CreateMap<Category, CategoryDto>();
            this.CreateMap<SubCategory, SubCategoryDto>();
            this.CreateMap<Tag, TagDto>().ReverseMap();
            this.CreateMap<Tag, SubscriptionsDto>().ReverseMap();
            this.CreateMap<UserTag, UserTagDto>().ReverseMap();
            this.CreateMap<UserTag, UserTagDto>();
            this.CreateMap<User, UserDto>();
            this.CreateMap<User, UserDto>().ReverseMap();
            this.CreateMap<SubscribeTagDto, UserTag>().ReverseMap();
            this.CreateMap<UserArticle, UserArticleDto>().ReverseMap(); 
            this.CreateMap<Comment, CommentDto>();
            this.CreateMap<CommentDto, Comment>();
            this.CreateMap<Reply, ReplyDto>();
            this.CreateMap<ReplyDto, Reply>();
            this.CreateMap<TagArticle, PolarChartTags>();
        }
    }
}
