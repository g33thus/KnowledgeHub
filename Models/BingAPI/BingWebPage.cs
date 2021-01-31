using System;

namespace Employee_Hub.Models.BingAPI
{
    public class BingWebPage
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string DisplayUrl { get; set; }

        public string Snippet { get; set; }

        public DateTime DateLastCrawled { get; set; }

        public string CachedPageUrl { get; set; }

        public OpenGraphImage OpenGraphImage { get; set; }
    }
}
