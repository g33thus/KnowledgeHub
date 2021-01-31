using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;

namespace Employee_Hub.Managers.Interfaces
{
    public interface ITagManager
    {
        public List<SubscriptionsDto> GetTags(int subCategoryId, int userId);

        public Task<bool> SubscribeToTag(SubscribeTagDto subscribeTagDto);

        public Task<bool> UnSubscribeTagAsync(int userTagId);
    }
}
