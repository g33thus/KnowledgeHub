using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.Filters;
using Employee_Hub.Models;
using Employee_Hub.Models.BingAPI;
using Employee_Hub.Models.NewsAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Employee_Hub.Accessor
{
    public class ArticleAccessor : IArticleAccessor
    {
        private readonly KnowledgeHubDataBaseContext _knowledgeHubDataBaseContext;
        private readonly IConfiguration _configuration;
        private readonly HttpClient client = new HttpClient();

        public ArticleAccessor(IConfiguration configuration, KnowledgeHubDataBaseContext knowledgeHubDataBaseContext)
        {
            _configuration = configuration;
            _knowledgeHubDataBaseContext = knowledgeHubDataBaseContext;
        }

        public async Task<BingSearchResponse> GetBingApiArticles(string searchTerm)
        {
            try
            {
                string subscriptionKey = _configuration.GetValue<string>("BingSubscriptionKey");
                string customConfigId = _configuration.GetValue<string>("BingCustomConfigId");
                string bingURI = _configuration.GetValue<string>("BingURI");
                string url = bingURI + "q=" + searchTerm + "&customconfig=" + customConfigId;

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                HttpResponseMessage httpResponseMessage = await Task<HttpResponseMessage>.FromResult(client.GetAsync(url).Result);
                string responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                BingSearchResponse response = JsonConvert.DeserializeObject<BingSearchResponse>(responseContent);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<NewsApiResponse>> GetNewsApiArticles(string searchTerm, int tagId)
        {
            try
            {
                var context = new KnowledgeHubDataBaseContext();
                var userArticleList = context.UserArticle.Where(userArticle => userArticle.TagId == tagId).ToList();
                DateTime startDate = (userArticleList.Count > 0) ? userArticleList.Max(u => u.CreatedDate) : DateTime.Now.AddDays(-30);
                string apiKey = _configuration.GetValue<string>("NewsApiKey");
                string newsApiURI = _configuration.GetValue<string>("NewsApiURI");
                string url = newsApiURI + "qInTitle=" + searchTerm + "&language=en&from=" + startDate + "&sortBy=publishedAt&apiKey=" + apiKey;
                HttpResponseMessage httpResponseMessage = await Task<HttpResponseMessage>.FromResult(client.GetAsync(url).Result);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    List<NewsApiResponse> response = JsonConvert.DeserializeObject<NewsAPIRootJson>(responseContent).Articles.ToList();
                    return response;
                }
                return new List<NewsApiResponse>();
            }
            catch (Exception ex)
            {
                return null;
            }
            }

        public async Task<int> AddArticlesToArticlesTableAsync(Article articleToAdd)
        {
            var context = new KnowledgeHubDataBaseContext();
            //context.ChangeTracker.AutoDetectChangesEnabled = false;
            try
            {

                Article articleExists = context.Article.FirstOrDefault(article => article.Url == articleToAdd.Url);
                if (articleExists == null)
                {
                    Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Article> article = context.Article.Add(articleToAdd);
                    await context.SaveChangesAsync();
                    return article.Entity.Id;
                }
                return articleExists.Id;
            }
            catch(Exception ex){
                var fallback= context.Article.FirstOrDefault(article => article.Url == articleToAdd.Url);
                if (fallback != null)
                {
                    return fallback.Id;
                }
                return 0;
            }
        }

        public async Task AddArticlesToUserTableAsync(UserArticle userArticle, int tagId, int userId)
        {
            var context = new KnowledgeHubDataBaseContext();
            //context.ChangeTracker.AutoDetectChangesEnabled = false;
            try
            {
                userArticle.TagId = context.UserTag.FirstOrDefault(t => t.UserId == userId && t.TagId == tagId).Id;
                context.UserArticle.Add(userArticle);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public List<UserArticle> GetArticlesFromDatabase(int userId, int? tagId, PagingFilter pagingFilter)
        {
            List<UserArticle> userArticlesList = new List<UserArticle>();
            if (tagId != null)
            {
                userArticlesList = _knowledgeHubDataBaseContext.UserArticle.Where(userArticle => userArticle.UserId == userId && userArticle.TagId == tagId).Include(u=>u.Article).Include(u=>u.Tag).ToList();
            }
            else
            {
                userArticlesList = _knowledgeHubDataBaseContext.UserArticle.Where(userArticle => userArticle.UserId == userId).Include(u => u.Article).Include(u => u.Tag).ToList();
                
            }
            if (userArticlesList.Count>0)
            {
                return userArticlesList.Skip((pagingFilter.PageNumber - 1) * pagingFilter.PageSize)
                                    .Take(pagingFilter.PageSize).OrderBy(u=>u.CreatedDate).ToList();
            }
            return null;
        }
    }
}
