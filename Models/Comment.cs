using System;
using System.Collections.Generic;

namespace Employee_Hub.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Reply = new HashSet<Reply>();
        }

        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
    }
}
