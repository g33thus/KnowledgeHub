namespace Employee_Hub.Models.BingAPI
{
    public class BingWebPages
    {
        public string WebSearchUrl { get; set; }

        public int TotalEstimatedMatches { get; set; }

        public BingWebPage[] Value { get; set; }
    }
}
