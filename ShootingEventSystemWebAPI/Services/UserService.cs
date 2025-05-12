using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetById(int id);
        UserDto GetByEmail(string email);
    }
    public class UserService:IUserService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public UserService(TournamentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var allUsers = _dbContext.Users.ToList();
            var usersDtos = _mapper.Map<List<UserDto>>(allUsers);

            return usersDtos;
        }

        public UserDto GetById(int id) 
        { 
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public UserDto GetByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

    }
}
