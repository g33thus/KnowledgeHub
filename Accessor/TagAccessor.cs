using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.Models;

namespace Employee_Hub.Accessor
{
    public class TagAccessor : ITagAccessor
    {
        private readonly KnowledgeHubDataBaseContext knowledgeHubDataBaseContext;

        public TagAccessor(KnowledgeHubDataBaseContext knowledgeHubDataBaseContext)
        {
            this.knowledgeHubDataBaseContext = knowledgeHubDataBaseContext;
        }

        public IEnumerable<Tag> GetTags(int subCategoryId)
        {
            return this.knowledgeHubDataBaseContext.Tag.Where(tag => tag.SubCategoryId == subCategoryId).ToList();
        }

        public IEnumerable<UserTag> GetUserTags(int userId)
        {
            return this.knowledgeHubDataBaseContext.UserTag.Where(userTag => userTag.UserId == userId).ToList();
        }

        public async Task<bool> SubscribeToTag(UserTag userTag)
        {
           this.knowledgeHubDataBaseContext.UserTag.Add(userTag);
           var userTagAddedCount = await this.knowledgeHubDataBaseContext.SaveChangesAsync();
           return userTagAddedCount == 1;
        }

        public async Task<bool> UnSubscribeTag(int userTagId)
        {
            UserTag userTagToRemove = await this.knowledgeHubDataBaseContext.UserTag.FindAsync(userTagId);
            this.knowledgeHubDataBaseContext.UserTag.Remove(userTagToRemove);
            var userTagAddedCount = await this.knowledgeHubDataBaseContext.SaveChangesAsync();
            return userTagAddedCount == 1;
        }
    }
}
