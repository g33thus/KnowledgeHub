using System.Threading.Tasks;
using Employee_Hub.DTOs;

namespace Employee_Hub.Engines.Interfaces
{
    public interface IUserEngine
    {
        public Task<int> AddUser(UserDto userDto);
    }
}
