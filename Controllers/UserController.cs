using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Managers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Hub.Controllers
{
    [EnableCors("AllowCors")]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        /// <summary>
        /// Adds the user to database if not present.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns> UserId from database</returns>
        [HttpPost]
        public async Task<int> AddUser([FromBody] UserDto userDto)
        {
            return await this._userManager.AddUser(userDto);
        }
    }
}
