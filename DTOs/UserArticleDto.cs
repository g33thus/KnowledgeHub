using System;
using System.Collections.Generic;

namespace Employee_Hub.DTOs
{
    public class UserArticleDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ArticleId { get; set; }

        public bool IsLiked { get; set; }

        public bool IsSaved { get; set; }

        public bool IsMarkedRead { get; set; }

        public int TagId { get; set; }

        public ArticleDto Article { get; set; }
        public UserTagDto Tag { get; set; }
        public UserDto User { get; set; }
    }
}