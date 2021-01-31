using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;

namespace Employee_Hub.Managers.Interfaces
{
    public interface IArticleManager
    {
        Task<List<ArticleDto>> GetArticles(GetArticlesDTO getArticlesDTOe);

        List<UserArticleDto> GetArticlesFromDatabase(GetArticlesFromDBDTO getArticlesFromDBDTO);
    }
}
