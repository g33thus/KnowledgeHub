using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;

namespace Employee_Hub.Engines.Interfaces
{
    public interface ITagEngine
    {
        public List<SubscriptionsDto> GetTags(int subCategoryId, int userId);

        public Task<bool> SubscribeToTagAsync(SubscribeTagDto subscribeTagDto);

        public Task<bool> UnSubscribeTagAsync(int userTagId);
    }
}
