using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Managers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Hub.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserArticleController : ControllerBase
    {
        private readonly IUserArticleManager userArticleManager;

        public UserArticleController(IUserArticleManager userArticleManager)
        {
            this.userArticleManager = userArticleManager;
        }

        [HttpGet("Comments")]
        public async Task<List<CommentDto>> GetComment(int articleId)
        {
            List<CommentDto> comments = await this.userArticleManager.GetComment(articleId);
            return comments;
        }

        [HttpPost("Reply")]
        public async Task<bool> AddReply([FromBody] ReplyDto replyDto)
        {
            return await this.userArticleManager.AddReply(replyDto);
        }

        [HttpPost("Comment")]
        public async Task<bool> AddComment([FromBody] CommentDto commentDto)
        {
            return await this.userArticleManager.AddComment(commentDto);
        }

        [HttpPut("UpdateUserArticle")]
        public async Task<bool> UpdateUserArticle([FromBody] UserArticleDto userArticleDto)
        {
            return await this.userArticleManager.UpdateUserArticle(userArticleDto);
        }

        [HttpGet]
        [Route("Dashboard/{userId}")]
        public Task<ArticleInfoDto> GetArticleInfo(int userId)
        {
            return this.userArticleManager.GetArticleInfo(userId);
        }
    }
}
