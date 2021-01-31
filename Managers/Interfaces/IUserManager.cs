using System.Threading.Tasks;
using Employee_Hub.DTOs;

namespace Employee_Hub.Managers.Interfaces
{
    public interface IUserManager
    {
        public Task<int> AddUser(UserDto userDto);
    }
}