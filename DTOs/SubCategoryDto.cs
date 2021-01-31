using Employee_Hub.Models;
using System.Collections.Generic;

namespace Employee_Hub.DTOs
{
    public class SubCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }
        public  Category Category { get; set; }
        public IEnumerable<TagDto> TagDto { get; set; }
    }
}
