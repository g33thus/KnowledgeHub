using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Filters;
using Employee_Hub.Models;
using Employee_Hub.Models.BingAPI;

namespace Employee_Hub.Engines
{
    public class ArticleEngine : IArticleEngine
    {
        private readonly IArticleAccessor _articleAccessor;
        private readonly IMapper _mapper;

        public ArticleEngine(IArticleAccessor articleAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _articleAccessor = articleAccessor;
        }

        public async Task<List<ArticleDto>> GetBingApiArticles(string searchTerm)
        {
            List<ArticleDto> bingArticleList = new List<ArticleDto>();
            BingSearchResponse bingResponse = await _articleAccessor.GetBingApiArticles(searchTerm);
            if (bingResponse?.WebPages!=null) { 
            foreach (BingWebPage bingArticle in bingResponse?.WebPages?.Value)
            {
                ArticleDto article = new ArticleDto()
                {
                    Description = bingArticle.Snippet,
                    PublishedAt = bingArticle.DateLastCrawled,
                    Title = bingArticle.Name,
                    Url = bingArticle.DisplayUrl,
                    UrlToImage = bingArticle.OpenGraphImage?.ContentUrl,
                    Likes = 0,
                };
                bingArticleList.Add(article);
            }
            }

            return bingArticleList;
        }

        public async Task<List<ArticleDto>> GetNewsApiArticles(string searchTerm, int tagId)
        {
            IEnumerable<Models.NewsAPI.NewsApiResponse> newsApiResponse = await _articleAccessor.GetNewsApiArticles(searchTerm, tagId);
            List<ArticleDto> newsApiArticles = _mapper.Map<List<ArticleDto>>(newsApiResponse.ToList());
            return newsApiArticles.ToList();
        }

        public async Task AddArticlesAsync(int userId, int tagId, List<ArticleDto> allArticles)
        {
            foreach (ArticleDto article in allArticles)
            {
                Article articleToAdd = _mapper.Map<Article>(article);
                if (!string.IsNullOrEmpty(articleToAdd.Snippet))
                {
                    int articleAddedId = await _articleAccessor.AddArticlesToArticlesTableAsync(articleToAdd);
                    if (articleAddedId != 0)
                    {
                        UserArticle userArticle = new UserArticle()
                        {
                            UserId = userId,
                            ArticleId = articleAddedId,
                            CreatedDate = DateTime.Now,
                            IsLiked = false,
                            IsSaved = false,
                            IsMarkedRead = false,
                        };
                        await _articleAccessor.AddArticlesToUserTableAsync(userArticle, tagId, userId);
                    }
                }
            }
        }

        public List<UserArticleDto> GetArticlesFromDatabase(GetArticlesFromDBDTO getArticlesFromDBDTO)
        {
            PagingFilter validFilter = new PagingFilter(getArticlesFromDBDTO.PageNumber);
            List<UserArticle> databaseArticleList = _articleAccessor.GetArticlesFromDatabase(getArticlesFromDBDTO.UserId, getArticlesFromDBDTO.UserTagId, validFilter);
            return _mapper.Map<List<UserArticleDto>>(databaseArticleList);
        }
    }
}
