using System.Collections.Generic;
using Employee_Hub.Filters;
using Employee_Hub.Models;
using System.Threading.Tasks;
using Employee_Hub.Models.BingAPI;
using Employee_Hub.Models.NewsAPI;

namespace Employee_Hub.Accessor.Interfaces
{
    public interface IArticleAccessor
    {
        Task<BingSearchResponse> GetBingApiArticles(string searchTerm);

        Task<IEnumerable<NewsApiResponse>> GetNewsApiArticles(string tag, int tagId);

        Task<int> AddArticlesToArticlesTableAsync(Article articles);

        Task AddArticlesToUserTableAsync(UserArticle userArticle, int tagId, int userId);

        List<UserArticle> GetArticlesFromDatabase(int userId, int? tagId, PagingFilter validFilter);
    }
}
