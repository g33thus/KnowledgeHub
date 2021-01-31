using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.Models;

namespace Employee_Hub.Accessor.Interfaces
{
   public interface ICategoryAccessor
    {
        public IEnumerable<Category> GetCategory();
        public IEnumerable<UserTag> GetUserTags(int userId);
        Task<bool> AddCategory(Category category);
        Task<bool> AddSubCategory(SubCategory subCategory);
        Task<bool> AddTag(Tag tag);

    }
}
