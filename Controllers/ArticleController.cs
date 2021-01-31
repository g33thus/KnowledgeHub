using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Managers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Hub.Controllers
{
    [EnableCors("AllowCors")]
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleManager _articleManager;

        public ArticleController(IArticleManager articleManager)
        {
            this._articleManager = articleManager;
        }

        /// <summary>
        /// To get articles from News API and Bing with userId and List of tags.
        /// SubcategoryId is not a required parameter.
        /// </summary>
        /// <returns> List of articles</returns>
        [HttpPost]
        public async Task<List<ArticleDto>> GetArticles([FromBody]GetArticlesDTO getArticlesDTO)
        {
            return await this._articleManager.GetArticles(getArticlesDTO);
        }

        /// <summary>
        /// To get articles stored in database with userId and userTags.
        /// Set userTags as null to fetch all user subscribed articles.
        /// PageNumber to be passed for fetching articles on dynamic scroll.
        /// </summary>
        /// <returns> List of User Articles</returns>
        [HttpPost("db")]
        public List<UserArticleDto> GetArticlesFromDatabase([FromBody]GetArticlesFromDBDTO getArticlesFromDBDTO)
        {
            return this._articleManager.GetArticlesFromDatabase(getArticlesFromDBDTO);
        }
    }
}