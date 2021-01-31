using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Employee_Hub.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
