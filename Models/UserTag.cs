using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Hub.Models
{
    public partial class UserTag
    {
        public UserTag()
        {
            UserArticle = new HashSet<UserArticle>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<UserArticle> UserArticle { get; set; }
    }
}
