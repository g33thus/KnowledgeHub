using System;
using NewsAPI.Models;

namespace Employee_Hub.Models.NewsAPI
{
    public class NewsApiResponse
    {
        public Source? Source { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string UrlToImage { get; set; }

        public DateTime? PublishedAt { get; set; }
    }
}
