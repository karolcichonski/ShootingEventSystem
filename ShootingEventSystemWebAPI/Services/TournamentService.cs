using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface ITournamentService
    {
        Task<IEnumerable<TournamentDto>> GetAllTournamentsAsync();
        TournamentDto GetById(int id);
        int CreateTournament(CreateTournamentDto tournamentDto);
    }
    public class TournamentService : ITournamentService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;
        public TournamentService(TournamentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TournamentDto>> GetAllTournamentsAsync()
        {
            var allTournaments = await _dbContext.Tournaments.ToListAsync();
            var tournamentsDtos = _mapper.Map<IEnumerable<TournamentDto>>(allTournaments);

            return tournamentsDtos;
        }

        public int CreateTournament(CreateTournamentDto tournamentDto)
        {
            var tournament = _mapper.Map<CreateTournamentDto, Tournament>(tournamentDto);
            _dbContext.Tournaments.Add(tournament);
            _dbContext.SaveChanges();

            return tournament.Id;
        }

        public TournamentDto GetById(int id)
        {
            var tournament = _dbContext.Tournaments.FirstOrDefault(x => x.Id == id);
            if (tournament == null)
            {
                throw new Exception("Tournament not found");
            }
            var tournamentDto = _mapper.Map<TournamentDto>(tournament);
            return tournamentDto;
        }
    }
}
