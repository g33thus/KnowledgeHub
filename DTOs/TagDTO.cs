namespace Employee_Hub.DTOs
{
    public class TagDto
    {
        public int Id { get; set; }

        public int SubCategoryId { get; set; }

        public string Name { get; set; }

        public SubCategoryDto SubCategory { get; set; }
    }
}
