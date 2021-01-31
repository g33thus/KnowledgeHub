using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Hub.Models
{
    public partial class UserArticle
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ArticleId { get; set; }
        public bool IsLiked { get; set; }
        public bool IsSaved { get; set; }
        public bool IsMarkedRead { get; set; }
        public int TagId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
        [ForeignKey("TagId")]
        public virtual UserTag Tag { get; set; }
        public virtual User User { get; set; }
    }
}
