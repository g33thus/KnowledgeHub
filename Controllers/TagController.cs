using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Managers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Hub.Controllers
   {
    [EnableCors("AllowCors")]
    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagManager tagManager;

        public TagController(ITagManager tagManager)
        {
            this.tagManager = tagManager;
        }

        [HttpGet]
        public List<SubscriptionsDto> GetTags([FromQuery] int subCategoryId, [FromQuery] int userId)
        {
            return this.tagManager.GetTags(subCategoryId, userId);
        }

        [HttpPost("subscribe")]
        public async Task<bool> SubscribeToTagAsync([FromBody] SubscribeTagDto subscribeTagDto)
        {
            return await this.tagManager.SubscribeToTag(subscribeTagDto);
        }

        [HttpDelete("unsubscribe")]
        public async Task<bool> UnSubscribeTag([FromQuery] int userTagId)
        {
            return await this.tagManager.UnSubscribeTagAsync(userTagId);
        }
    }
}
