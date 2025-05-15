using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface IResultService
    {
        IEnumerable<ResultDto> GetAllResults();
        ResultDto GetById(int id);
        IEnumerable<ResultDto> GetResultsFromTournament(int TournamentId, int CompetitorId);
        int CreateResult(CreateResultDto resultDto);


    }
    public class ResultService: IResultService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;

        public ResultService(TournamentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int CreateResult(CreateResultDto resultDto)
        {
            var result = _mapper.Map<CreateResultDto, Result>(resultDto);
            _dbContext.Results.Add(result);
            _dbContext.SaveChanges();

            return result.Id;
        }

        public IEnumerable<ResultDto> GetAllResults()
        {
            var allResults = _dbContext.Results.ToList();
            var resultsDtos = _mapper.Map<List<ResultDto>>(allResults);

            return resultsDtos;
        }

        public ResultDto GetById(int id)
        {
            var result = _dbContext.Results.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("Result not found");
            }
            var resultDto = _mapper.Map<ResultDto>(result);
            return resultDto;
        }

        public IEnumerable<ResultDto> GetResultsFromTournament(int TournamentId, int CompetitorId)
        {
            var results = _dbContext.Results
                .Where(x => x.TournamentId == TournamentId && x.CompetitorId == CompetitorId)
                .ToList();
            if (results == null)
            {
                throw new Exception("Results not found");
            }
            var resultsDto = _mapper.Map<List<ResultDto>>(results);
            return resultsDto;
        }
    }
}
