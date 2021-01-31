using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.DTOs;
using Employee_Hub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Hub.Accessor
{
    public class UserArticleAccessor : IUserArticleAccessor
    {
        private readonly KnowledgeHubDataBaseContext knowledgeHubDataBaseContext;

        public UserArticleAccessor(KnowledgeHubDataBaseContext knowledgeHubDataBaseContext)
        {
            this.knowledgeHubDataBaseContext = knowledgeHubDataBaseContext;
        }

        public async Task<List<Comment>> GetComment(int articleId)
        {
            List<Comment> allComments = await this.knowledgeHubDataBaseContext.Comment.Where(p => p.ArticleId == articleId).Include(s => s.User).Include(r => r.Reply).ThenInclude(t => t.User).ToListAsync();
            return allComments;
        }

        public async Task<bool> AddReply(Reply reply)
        {
            this.knowledgeHubDataBaseContext.Reply.Add(reply);
            return await this.knowledgeHubDataBaseContext.SaveChangesAsync() != 0;
        }

        public async Task<bool> AddComment(Comment comment)
        {
            this.knowledgeHubDataBaseContext.Comment.Add(comment);
            return await this.knowledgeHubDataBaseContext.SaveChangesAsync() != 0;
        }

        public async Task<bool> UpdateUserArticle(UserArticleDto userArticleDto)
        {
            UserArticle userArticle = this.knowledgeHubDataBaseContext.UserArticle.FirstOrDefault(p => p.Id == userArticleDto.Id);
            if (userArticle != null)
            {
                userArticle.IsSaved = userArticleDto.IsSaved;
                userArticle.IsMarkedRead = userArticleDto.IsMarkedRead;
                userArticle.IsLiked = userArticleDto.IsLiked;
                if (userArticleDto.IsLiked)
                {
                    this.knowledgeHubDataBaseContext.Article.FirstOrDefault(p => p.Id == userArticleDto.ArticleId).Likes++;
                }
                return await this.knowledgeHubDataBaseContext.SaveChangesAsync() != 0;
            }  
            return false;
        }

        public List<UserArticle> GetUserArticles(int userId)
        {
            return this.knowledgeHubDataBaseContext.UserArticle.Where(a => a.UserId == userId).ToList();
        }
        public List<TagArticle> GetTopTags(int userId)
        {
            List<TagArticle> tagArticles = new List<TagArticle>();
            var userTags = this.knowledgeHubDataBaseContext.UserArticle.Where(u => u.UserId == userId).Include(u=>u.Tag).ToList();
            var groupedtags= userTags.GroupBy(u => u.TagId).OrderByDescending(p => p.Count()).Take(5).ToList();
            foreach (var groupedtag in groupedtags)
            {
                tagArticles.Add(new TagArticle()
                {
                    NoOfArticles = groupedtag.Count(),
                    TagName = this.knowledgeHubDataBaseContext.UserTag.Where(p => p.Id == groupedtag.Key).Include(u=>u.Tag).First().Tag.Name,
                });
            }
            return tagArticles;
        }
        public Article GetTrendingArticle(int userId)
        {
            List<int> articleIds = this.knowledgeHubDataBaseContext.UserArticle.Where(a => a.UserId == userId).Select(a=>a.ArticleId).ToList();
            var articleList = this.knowledgeHubDataBaseContext.Article.Where(a => articleIds.Contains(a.Id)).ToList();
            return articleList.OrderByDescending(a => a.Likes).FirstOrDefault();
        }
    }
}
