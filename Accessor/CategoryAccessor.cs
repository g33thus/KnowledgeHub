using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Hub.Accessor
{
    public class CategoryAccessor : ICategoryAccessor
    {
        private readonly KnowledgeHubDataBaseContext knowledgeHubDataBaseContext;

        public CategoryAccessor(KnowledgeHubDataBaseContext knowledgeHubDataBaseContext)
        {
            this.knowledgeHubDataBaseContext = knowledgeHubDataBaseContext;
        }

        public IEnumerable<Category> GetCategory()
        {
            return this.knowledgeHubDataBaseContext.Category.Include(subCategory => subCategory.SubCategory).ToList();
        }

        public IEnumerable<UserTag> GetUserTags(int userId)
        {

            var l = this.knowledgeHubDataBaseContext.UserTag.Include(a => a.Tag).Where(a=>a.UserId == userId);
            var tags = (from u in this.knowledgeHubDataBaseContext.UserTag
                        join t in this.knowledgeHubDataBaseContext.Tag on u.TagId equals t.Id
                        where u.UserId == userId
                        select u).Include(s => s.Tag).ThenInclude(c => c.SubCategory).ThenInclude(s => s.Category).ToList();

            return tags;
        }

        public async Task<bool> AddCategory(Category category)
        {
            Category dbCategory = this.knowledgeHubDataBaseContext.Category.FirstOrDefault(c => c.Id == category.Id);
            if (dbCategory != null)
            {
                dbCategory.Name = category.Name;
            }
            else
            {
                this.knowledgeHubDataBaseContext.Category.Add(category);
            }
            var categoryAddedCount = await this.knowledgeHubDataBaseContext.SaveChangesAsync();
            return categoryAddedCount == 1;
        }
        public async Task<bool> AddSubCategory(SubCategory subCategory)
        {
            SubCategory dbSubCategory = this.knowledgeHubDataBaseContext.SubCategory.FirstOrDefault(c => c.Id == subCategory.Id);
            if (dbSubCategory != null)
            {
                dbSubCategory.Name = subCategory.Name;
                dbSubCategory.CategoryId = subCategory.CategoryId;
            }
            else
            {
                this.knowledgeHubDataBaseContext.SubCategory.Add(subCategory);
            }
            var subCategoryAddedCount = await this.knowledgeHubDataBaseContext.SaveChangesAsync();
            return subCategoryAddedCount == 1;
        }
        public async Task<bool> AddTag(Tag tag)
        {
            Tag dbTag = this.knowledgeHubDataBaseContext.Tag.FirstOrDefault(c => c.Id == tag.Id);
            if (dbTag != null)
            {
                dbTag.Name = tag.Name;
                dbTag.SubCategoryId = tag.SubCategoryId;
            }
            else 
            { 
                this.knowledgeHubDataBaseContext.Tag.Add(tag);
            }
            var tagAddedCount = await this.knowledgeHubDataBaseContext.SaveChangesAsync();
            return tagAddedCount == 1;
        }
    }
}
