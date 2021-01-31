using System;
using System.Collections.Generic;

namespace Employee_Hub.Models
{
    public partial class Article
    {
        public Article()
        {
            Comment = new HashSet<Comment>();
            UserArticle = new HashSet<UserArticle>();
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string ImageUrl { get; set; }
        public string Snippet { get; set; }
        public int Likes { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<UserArticle> UserArticle { get; set; }
    }
}
