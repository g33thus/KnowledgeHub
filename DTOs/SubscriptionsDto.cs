namespace Employee_Hub.DTOs
{
    public class SubscriptionsDto
    {
        public int Id { get; set; }

        public int UserTagId { get; set; }

        public int SubCategoryId { get; set; }

        public string Name { get; set; }

        public bool IsUserSubscribed { get; set; }

        public SubCategoryDto SubCategory { get; set; }
    }
}
