using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Hub.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Tag = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
    }
}
