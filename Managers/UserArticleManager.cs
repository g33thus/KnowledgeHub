using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Hub.Managers
{
    public class UserArticleManager : IUserArticleManager
    {
        private readonly IUserArticleEngine _userArticleEngine;

        public UserArticleManager(IUserArticleEngine userArticleEngine)
        {
            this._userArticleEngine = userArticleEngine;
        }

        public async Task<List<CommentDto>> GetComment(int articleId)
        {
            return await this._userArticleEngine.GetComment(articleId);
        }

        public async Task<bool> AddReply(ReplyDto replyDto)
        {
            return await this._userArticleEngine.AddReply(replyDto);
        }

        public async Task<bool> AddComment(CommentDto commentDto)
        {
            return await this._userArticleEngine.AddComment(commentDto);
        }

        public async Task<bool> UpdateUserArticle(UserArticleDto userArticleDto)
        {   
            
            return await this._userArticleEngine.UpdateUserArticle(userArticleDto);
        }
        public Task<ArticleInfoDto> GetArticleInfo(int userId)
        {
            return this._userArticleEngine.GetArticleInfo(userId);
        }
    }
}
