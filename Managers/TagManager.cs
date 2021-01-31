using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Managers.Interfaces;

namespace Employee_Hub.Managers
{
    public class TagManager : ITagManager
    {
        private readonly ITagEngine _tagEngine;

        public TagManager(ITagEngine tagEngine)
        {
            this._tagEngine = tagEngine;
        }

        public List<SubscriptionsDto> GetTags(int subCategoryId, int userId)
        {
            return this._tagEngine.GetTags(subCategoryId, userId);
        }

        public async Task<bool> SubscribeToTag(SubscribeTagDto subscribeTagDto)
        {
            return await this._tagEngine.SubscribeToTagAsync(subscribeTagDto);
        }

        public async Task<bool> UnSubscribeTagAsync(int userTagId)
        {
            return await this._tagEngine.UnSubscribeTagAsync(userTagId);
        }
    }
}
