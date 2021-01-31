using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.Models;

namespace Employee_Hub.Accessor.Interfaces
{
   public interface ITagAccessor
    {
        public IEnumerable<Tag> GetTags(int subCategoryId);

        public IEnumerable<UserTag> GetUserTags(int userId);

        public Task<bool> SubscribeToTag(UserTag userTag);

        public Task<bool> UnSubscribeTag(int userTagId);
    }
}
