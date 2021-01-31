using System.Collections.Generic;

namespace Employee_Hub.DTOs
{
    public class UserTagDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TagId { get; set; }

  
        public  TagDto Tag { get; set; }
        public UserDto User { get; set; }
    }
}