using Employee_Hub.DTOs;
using Employee_Hub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Hub.Managers.Interfaces
{
    public interface IUserArticleManager
    {
        public Task<List<CommentDto>> GetComment(int articleId);

        public Task<bool> UpdateUserArticle(UserArticleDto userArticleDto);
        public Task<ArticleInfoDto> GetArticleInfo(int userId);

        public Task<bool> AddComment(CommentDto commentDto);

        public Task<bool> AddReply(ReplyDto replyDto);
    }
}
