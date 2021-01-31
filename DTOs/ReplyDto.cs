using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Hub.DTOs
{
    public class ReplyDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }

        public virtual UserDto User { get; set; }
    }
}
