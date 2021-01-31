using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Managers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Hub.Controllers
   {
    [EnableCors("AllowCors")]
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> GetCategory()
        {
          return this.categoryManager.GetCategory();
        }


        [HttpGet("withUserId")]
        public IEnumerable<UserTagDto> GetUserTags([FromQuery] int userId)
        {
            return this.categoryManager.GetUserTags(userId);
        }

        [HttpPost]
        public async Task<bool> AddNewTag([FromBody]List<PostTagAdmin> postTagAdminList)
        {
            return await this.categoryManager.AddNewTagAsync(postTagAdminList);
        }
    }
}
