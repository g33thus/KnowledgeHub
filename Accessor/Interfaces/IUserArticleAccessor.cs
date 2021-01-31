using Employee_Hub.DTOs;
using Employee_Hub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Hub.Accessor.Interfaces
{
    public interface IUserArticleAccessor
    {
        public Task<List<Comment>> GetComment(int articleId);

        public Task<bool> UpdateUserArticle(UserArticleDto userArticle);
      
        public List<UserArticle> GetUserArticles(int userId);
        public Task<bool> AddComment(Comment comment);

        public Task<bool> AddReply(Reply reply);

        public List<TagArticle> GetTopTags(int userId);

        public Article GetTrendingArticle(int userId);
    }
}
