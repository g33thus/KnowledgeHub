using System;
using System.Collections.Generic;

namespace Employee_Hub.Models
{
    public partial class Reply
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
