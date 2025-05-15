using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface ICompetitionService
    {
        public IEnumerable<CompetitionDto> GetAllCompetitions();
        public int CreateCompetition(CreateCompetitionDto competitionDto);
        public CompetitionDto GetById(int id);
        public CompetitionDto GetByName(string name);
    }
    public class CompetitionService: ICompetitionService
    {
        private readonly TournamentDbContext _tournamentDbContext;
        private readonly IMapper _mapper;
        public CompetitionService(TournamentDbContext tournamentDbContext, IMapper mapper)
        {
            _tournamentDbContext = tournamentDbContext;
            _mapper = mapper;
        }

        public  IEnumerable<CompetitionDto> GetAllCompetitions()
        {
            var competitions = _tournamentDbContext.Competitions.ToList();
            var competitionsDtos = _mapper.Map<List<CompetitionDto>>(competitions);

            return competitionsDtos;
        }

        public int CreateCompetition(CreateCompetitionDto competitionDto)
        {
            var competition = _mapper.Map<CreateCompetitionDto, Competition>(competitionDto);
            _tournamentDbContext.Competitions.Add(competition);
            _tournamentDbContext.SaveChanges();

            return competition.Id;
        }

        public CompetitionDto GetById(int id)
        {
            var competition = _tournamentDbContext.Competitions.FirstOrDefault(x => x.Id == id);
            if (competition == null)
            {
                throw new Exception("Competition not found");
            }
            var competitionDto = _mapper.Map<CompetitionDto>(competition);
            return competitionDto;
        }

        public CompetitionDto GetByName(string name)
        {
            var competition = _tournamentDbContext.Competitions.FirstOrDefault(x => x.Name == name);
            if (competition == null)
            {
                throw new Exception("Competition not found");
            }
            var competitionDto = _mapper.Map<CompetitionDto>(competition);
            return competitionDto;
        }
    }
}
