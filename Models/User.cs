using System.Collections.Generic;

namespace Employee_Hub.Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Reply = new HashSet<Reply>();
            UserArticle = new HashSet<UserArticle>();
            UserTag = new HashSet<UserTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
        public virtual ICollection<UserArticle> UserArticle { get; set; }
        public virtual ICollection<UserTag> UserTag { get; set; }
    }
}
