using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface ICompetitorService
    {
        IEnumerable<CompetitorDto> GetAllCompetitors();
        CompetitorDto GetById(int id);
        CompetitorDto GetByUserId(int userId);
        int CreateCompetitor(CreateCompetitorDto createCompetitorDto);

    }
    public class CompetitorService : ICompetitorService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;
        public CompetitorService(TournamentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int CreateCompetitor(CreateCompetitorDto createCompetitorDto)
        {
            var competitor = _mapper.Map<CreateCompetitorDto, Competitor>(createCompetitorDto);
            _dbContext.Competitors.Add(competitor);
            _dbContext.SaveChanges();

            return competitor.Id;
        }

        public IEnumerable<CompetitorDto> GetAllCompetitors()
        {
            var allCompetitors = _dbContext.Competitors.ToList();
            var competitorsDtos = _mapper.Map<List<CompetitorDto>>(allCompetitors);
            return competitorsDtos;
        }

        public CompetitorDto GetById(int id)
        {
            var competitor = _dbContext.Competitors.FirstOrDefault(x => x.Id == id);
            if (competitor == null)
            {
                throw new Exception("Competitor not found");
            }
            var competitorDto = _mapper.Map<CompetitorDto>(competitor);
            return competitorDto;
        }

        public CompetitorDto GetByUserId(int userId)
        {
            var competitor = _dbContext.Competitors.FirstOrDefault(x => x.UserId == userId);
            if (competitor == null)
            {
                throw new Exception("Competitor not found");
            }
            var competitorDto = _mapper.Map<CompetitorDto>(competitor);
            return competitorDto;
        }
    }
}
