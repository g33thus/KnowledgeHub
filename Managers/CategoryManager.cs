using System.Collections.Generic;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Managers.Interfaces;

namespace Employee_Hub.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryEngine categoryEngine;

        public CategoryManager(ICategoryEngine categoryEngine)
        {
            this.categoryEngine = categoryEngine;
        }

        public async System.Threading.Tasks.Task<bool> AddNewTagAsync(List<PostTagAdmin> postTagAdminList)
        {
            return await this.categoryEngine.AddNewTagAsync(postTagAdminList);
        }

        public IEnumerable<CategoryDto> GetCategory()
        {
           return this.categoryEngine.GetCategory();
        }

        public IEnumerable<UserTagDto> GetUserTags(int userId)
        {
            return this.categoryEngine.GetUserTAgs(userId);
        }
    }
}
