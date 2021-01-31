using System.Linq;
using System.Threading.Tasks;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Employee_Hub.Accessor
{
    public class UserAccessor : IUserAccessor
    {
        private readonly KnowledgeHubDataBaseContext knowledgeHubDataBaseContext;

        public UserAccessor(KnowledgeHubDataBaseContext knowledgeHubDataBaseContext)
        {
            this.knowledgeHubDataBaseContext = knowledgeHubDataBaseContext;
        }

        public async Task<int> AddUser(User user)
        {
            var userExistingInDB = this.knowledgeHubDataBaseContext.User.FirstOrDefault(dbUser => dbUser.Email == user.Email);
            if (userExistingInDB!=null)
            {
                return userExistingInDB.Id;
            }
            else
            {
                var addedUser = this.knowledgeHubDataBaseContext.User.Add(user);
                var userAddedCount = await this.knowledgeHubDataBaseContext.SaveChangesAsync();
                return addedUser.Entity.Id;
            }
        }
    }
}
