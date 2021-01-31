namespace Employee_Hub.Filters
{
    public class PagingFilter
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 

        public PagingFilter()
        {
            PageNumber = 1;
            PageSize = 10;

        }
        public PagingFilter(int pageNumber)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize =10;
        }
    }
}
