using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Models;

namespace Employee_Hub.Engines
{
    public class CategoryEngine :ICategoryEngine
    {

        private readonly ICategoryAccessor _categoryAccessor;
        private readonly IMapper _mapper;

        public CategoryEngine(ICategoryAccessor categoryAccessor, IMapper mapper)
        {
            this._categoryAccessor = categoryAccessor;
            this._mapper = mapper;
        }

        public async Task<bool> AddNewTagAsync(List<PostTagAdmin> postTagAdminList)
        {
            foreach (var postTagAdmin in postTagAdminList)
            { 
               if (postTagAdmin.CategoryName != null)
                {
                    Category category = new Category()
                    {
                        Id = postTagAdmin.CategoryId,
                        Name = postTagAdmin.CategoryName,
                    };
                   await this._categoryAccessor.AddCategory(category);
                }

                if (postTagAdmin.SubCategoryName != null)
                {
                    SubCategory subCategory = new SubCategory()
                    {
                        Id = postTagAdmin.SubCategoryId,
                        Name = postTagAdmin.SubCategoryName,
                        CategoryId = postTagAdmin.CategoryId,
                    };

                    await this._categoryAccessor.AddSubCategory(subCategory);
                }

                if (postTagAdmin.TagName != null)
                {
                    Tag tag = new Tag()
                    {
                        Id = postTagAdmin.TagId,
                        Name = postTagAdmin.TagName,
                        SubCategoryId = postTagAdmin.SubCategoryId,
                    };

                    await this._categoryAccessor.AddTag(tag);
                }
            }
            return true;
        }

        public IEnumerable<CategoryDto> GetCategory()
        {
           var categoryList = this._categoryAccessor.GetCategory();
           return this._mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categoryList);
        }

        public IEnumerable<UserTagDto> GetUserTAgs(int userId)
        {
            var categoryList = this._categoryAccessor.GetUserTags(userId);
            return this._mapper.Map<IEnumerable<UserTag>, IEnumerable<UserTagDto>>(categoryList);
        }

    }
}
