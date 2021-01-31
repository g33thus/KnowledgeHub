using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;

namespace Employee_Hub.Engines.Interfaces
{
    public interface IArticleEngine
    {
        Task<List<ArticleDto>> GetBingApiArticles(string searchTerm);

        Task<List<ArticleDto>> GetNewsApiArticles(string searchTerm, int tagId);

        Task AddArticlesAsync(int userId, int tagId, List<ArticleDto> allArticles);

        List<UserArticleDto> GetArticlesFromDatabase(GetArticlesFromDBDTO getArticlesFromDBDTO);
    }
}
