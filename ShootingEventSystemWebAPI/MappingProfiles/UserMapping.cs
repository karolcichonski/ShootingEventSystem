using AutoMapper;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Entities;

namespace ShootingEventSystemWebAPI.MappingProfiles
{
    public class UserMapping: Profile
    {
        public UserMapping() 
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
