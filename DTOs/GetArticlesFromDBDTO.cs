namespace Employee_Hub.DTOs
{
    public class GetArticlesFromDBDTO
    {
        public int UserId { get; set; }

        public int? UserTagId { get; set; }

        public int PageNumber { get; set; }
    }
}
