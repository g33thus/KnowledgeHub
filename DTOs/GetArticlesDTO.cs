using System;
using System.Collections.Generic;

namespace Employee_Hub.DTOs
{
    public class GetArticlesDTO
    {
        public int UserId { get; set; }

        public List<TagForArticlesDto> TagList { get; set; }
    }
}
