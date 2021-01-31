using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Hub.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubCategoryDto> SubCategory { get; set; }
    }
}
