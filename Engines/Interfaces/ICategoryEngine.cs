using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;

namespace Employee_Hub.Engines.Interfaces
{
    public interface ICategoryEngine
    {
        public IEnumerable<CategoryDto> GetCategory();
        public IEnumerable<UserTagDto> GetUserTAgs(int userId);
        Task<bool> AddNewTagAsync(List<PostTagAdmin> postTagAdminList);
    }
}
