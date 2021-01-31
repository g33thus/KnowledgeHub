namespace Employee_Hub.Models.NewsAPI
{
    public class NewsAPIRootJson
    {
        public string Status { get; set; }

        public int TotalResults { get; set; }

        public NewsApiResponse[] Articles { get; set; }
    }
}
