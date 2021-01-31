using AutoMapper;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Hub.Engines
{
    public class UserArticleEngine : IUserArticleEngine
    {
        private readonly IUserArticleAccessor _userArticleAccessor;
        private readonly IMapper _mapper;

        public UserArticleEngine(IUserArticleAccessor userArticleAccessor, IMapper mapper)
        {
            this._userArticleAccessor = userArticleAccessor;
            this._mapper = mapper;
        }

        public async Task<List<CommentDto>> GetComment(int articleId)
        {
            List<Comment> allComment = await this._userArticleAccessor.GetComment(articleId);
            return this._mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(allComment).ToList();
        }

        public async Task<bool> AddReply(ReplyDto replyDto)
        {
            Reply reply = this._mapper.Map<ReplyDto, Reply>(replyDto);
            return await this._userArticleAccessor.AddReply(reply);
        }

        public async Task<bool> AddComment(CommentDto commentDto)
        {
            Comment comment = this._mapper.Map<CommentDto, Comment>(commentDto);
            return await this._userArticleAccessor.AddComment(comment);
        }

        public async Task<bool> UpdateUserArticle(UserArticleDto userArticleDto)
        {
            return await this._userArticleAccessor.UpdateUserArticle(userArticleDto);
        }
        public async Task<ArticleInfoDto> GetArticleInfo(int userId) {
            var userArticlesList = this._userArticleAccessor.GetUserArticles(userId);
            ArticleInfoDto articleInfoDto = new ArticleInfoDto();           
            articleInfoDto.noOfArticlesLiked = userArticlesList.Count(a => a.IsLiked == true);
            articleInfoDto.noOfArticlesRead = userArticlesList.Count(a => a.IsMarkedRead == true);
            articleInfoDto.noOfArticlesSaved = userArticlesList.Count(a => a.IsSaved == true);
            articleInfoDto.noOfSubscribedTags = userArticlesList.Select(a => a.TagId).Distinct().Count();
            articleInfoDto.PolarChartTags = this._mapper.Map<List<TagArticle> ,List<PolarChartTags>>(this._userArticleAccessor.GetTopTags(userId));
            articleInfoDto.TrendingArticle = this._mapper.Map <Article,ArticleDto> (this._userArticleAccessor.GetTrendingArticle(userId));
            return articleInfoDto;
        }
    }
}
