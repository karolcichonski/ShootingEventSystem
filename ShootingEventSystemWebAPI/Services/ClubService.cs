using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface IClubService
    {
        Task<IEnumerable<ClubDto>> GetAllClubsAsync();
        int CreateClub(CreateClubDto clubDto);
        ClubDto GetById(int id);
        ClubDto GetByName(string name);
    }
    public class ClubService:IClubService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;
        public ClubService(TournamentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClubDto>> GetAllClubsAsync()
        {
            var allClubs = await _dbContext.Clubs.ToListAsync();
            var clubsDtos = _mapper.Map<IEnumerable<ClubDto>>(allClubs);

            return clubsDtos;
        }

        public int CreateClub(CreateClubDto clubDto)
        {
            var club = _mapper.Map<CreateClubDto, Club>(clubDto);
            _dbContext.Clubs.Add(club);
            _dbContext.SaveChanges();

            return club.Id;
        }

        public ClubDto GetById(int id)
        {
            var club = _dbContext.Clubs.FirstOrDefault(x => x.Id == id);
            if (club == null)
            {
                throw new Exception("Club not found");
            }
            var clubDto = _mapper.Map<ClubDto>(club);
            return clubDto;
        }

        public ClubDto GetByName(string name)
        {
            var club = _dbContext.Clubs.FirstOrDefault(x => x.Name == name);
            if (club == null)
            {
                throw new Exception("Club not found");
            }
            var clubDto = _mapper.Map<ClubDto>(club);
            return clubDto;
        }
    }
}
