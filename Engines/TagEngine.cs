using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Models;

namespace Employee_Hub.Engines
{
    public class TagEngine :ITagEngine
    {

        private readonly ITagAccessor _tagAccessor;
        private readonly IMapper _mapper;

        public TagEngine(ITagAccessor tagAccessor, IMapper mapper)
        {
            this._tagAccessor = tagAccessor;
            this._mapper = mapper;
        }

        public List<SubscriptionsDto> GetTags(int subCategoryId, int userId)
        {
            var tagList = this._tagAccessor.GetTags(subCategoryId);
            var userTagList = this._tagAccessor.GetUserTags(userId).ToList();
            List<SubscriptionsDto> subscriptionsList = new List<SubscriptionsDto>();
            foreach (var tag in tagList)
            {
                var userTagDB = userTagList.FirstOrDefault(usertag => usertag.TagId == tag.Id);
                subscriptionsList.Add(new SubscriptionsDto()
                {
                    Id = tag.Id,
                    UserTagId= (userTagDB != null)? userTagDB.Id:0,
                    Name = tag.Name,
                    IsUserSubscribed = userTagList.Any(usertag => usertag.TagId == tag.Id),
                    SubCategoryId = tag.SubCategoryId,
                    SubCategory = this._mapper.Map <SubCategory,SubCategoryDto>(tag.SubCategory),
                });
            }
            return subscriptionsList;

        }

        public async Task<bool> SubscribeToTagAsync(SubscribeTagDto subscribeTagDto)
        {
            UserTag userTag = this._mapper.Map<SubscribeTagDto, UserTag>(subscribeTagDto);
            return await this._tagAccessor.SubscribeToTag(userTag);
        }

        public async  Task<bool> UnSubscribeTagAsync(int userTagId)
        {
            return await this._tagAccessor.UnSubscribeTag(userTagId);
        }
    }
}
