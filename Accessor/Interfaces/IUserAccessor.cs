using System.Threading.Tasks;
using Employee_Hub.Models;

namespace Employee_Hub.Accessor.Interfaces
{
    public interface IUserAccessor
    {
        public Task<int> AddUser(User user);
    }
}
