using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        UserDto GetById(int id);
        UserDto GetByEmail(string email);
        int CreateUser(CreateUserDto CreateUserDto);
    }
    public class UserService:IUserService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(TournamentDbContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var allUsers = await _dbContext.Users.ToListAsync();
            var usersDtos = _mapper.Map<IEnumerable<UserDto>>(allUsers);

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

        public int CreateUser(CreateUserDto CreateUserDto)
        {
            var user = _mapper.Map<User>(CreateUserDto);
            user.Password = _passwordHasher.HashPassword(user, "password");
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

    }
}
