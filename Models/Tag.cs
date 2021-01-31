using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Hub.Models
{
    public partial class Tag
    {
   

        public int Id { get; set; }

        public int SubCategoryId { get; set; }

        public string Name { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }

      
    }
}
