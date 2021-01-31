using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Managers.Interfaces;

namespace Employee_Hub.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserEngine _userEngine;

        public UserManager(IUserEngine userEngine)
        {
            this._userEngine = userEngine;
        }

        public Task<int> AddUser(UserDto userDto)
        {
            return this._userEngine.AddUser(userDto);
        }
    }
}
