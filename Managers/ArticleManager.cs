using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Managers.Interfaces;

namespace Employee_Hub.Managers
{
    public class ArticleManager : IArticleManager
    {
        private readonly IArticleEngine _articleEngine;

        public ArticleManager(IArticleEngine articleEngine)
        {
            _articleEngine = articleEngine;
        }

        public async Task<List<ArticleDto>> GetArticles(GetArticlesDTO getArticlesDTO)
        {
            
            List<ArticleDto> allArticles = new List<ArticleDto>();
            try
            {
                Parallel.ForEach(getArticlesDTO.TagList, async (tag) =>
                {
                    List<ArticleDto> bingArticles = new List<ArticleDto>();
                    List<ArticleDto> newsApiArticles = new List<ArticleDto>();
                    Task[] getArticleTasks = new Task[]
                   {
                Task.Run(() => bingArticles =  this._articleEngine.GetBingApiArticles(tag.Name).Result),
                Task.Run(() => newsApiArticles =  this._articleEngine.GetNewsApiArticles(tag.Name, tag.Id).Result),
                   };
                    Task.WaitAll(getArticleTasks);
                    if (bingArticles.Count>0)
                    {
                        if (newsApiArticles.Count > 0)
                        {
                            allArticles.AddRange(newsApiArticles.Concat(bingArticles).ToList());
                        }
                        else
                        {
                            allArticles.AddRange(bingArticles);
                        }
                    }
                    else
                    {
                        allArticles.AddRange(newsApiArticles);
                    }
                    
                   Task.Run( () =>  this._articleEngine.AddArticlesAsync(getArticlesDTO.UserId, tag.Id, allArticles));
                });
            }
            catch(Exception ex)
            {
                return allArticles;
            }
            return allArticles;
        }

        List<UserArticleDto> IArticleManager.GetArticlesFromDatabase(GetArticlesFromDBDTO getArticlesFromDBDTO)
        {
            return this._articleEngine.GetArticlesFromDatabase(getArticlesFromDBDTO);
        }
    }
}
