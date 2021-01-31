using System.Threading.Tasks;
using AutoMapper;
using Employee_Hub.Accessor.Interfaces;
using Employee_Hub.DTOs;
using Employee_Hub.Engines.Interfaces;
using Employee_Hub.Models;

namespace Employee_Hub.Engines
{
    public class UserEngine : IUserEngine
    {
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public UserEngine(IUserAccessor userAccessor, IMapper mapper)
        {
            this._userAccessor = userAccessor;
            this._mapper = mapper;
        }

        public async Task<int> AddUser(UserDto userDto)
        {
            User user = this._mapper.Map<UserDto, User>(userDto);
            return await this._userAccessor.AddUser(user);
        }
    }
}
