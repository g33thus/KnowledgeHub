using System.Collections.Generic;

namespace Employee_Hub.DTOs
{
    public class ArticleInfoDto
    {
        public int noOfArticlesLiked { get; set; }
        public int noOfArticlesSaved { get; set; }
        public int noOfArticlesRead { get; set; }
        public int noOfSubscribedTags { get; set; }

        public List<PolarChartTags> PolarChartTags { get; set; }

        public ArticleDto TrendingArticle { get; set; }
    }
}
