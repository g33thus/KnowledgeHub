using Employee_Hub.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Hub.Engines.Interfaces
{
    public interface IUserArticleEngine
    {
        public Task<List<CommentDto>> GetComment(int articleId);

        public Task<bool> UpdateUserArticle(UserArticleDto userArticleDto);
        public Task<ArticleInfoDto> GetArticleInfo(int userId);
      
        public Task<bool> AddComment(CommentDto commentDto);

        public Task<bool> AddReply(ReplyDto replyDto);
    }
}
