using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Models;

namespace Employee_Hub.Managers.Interfaces
{
    public interface ICategoryManager
    {
        public IEnumerable<CategoryDto> GetCategory();
        public IEnumerable<UserTagDto> GetUserTags(int userId);
        Task<bool> AddNewTagAsync(List<PostTagAdmin> postTagAdminList);
    }
}
