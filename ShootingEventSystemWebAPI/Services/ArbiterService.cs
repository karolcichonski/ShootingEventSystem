using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface IArbiterService
    {
        public Task<IEnumerable<ArbiterDto>> GetAllArbitersAsync();
        public int CreateArbiter(CreateArbiterDto arbiterDto);
        public ArbiterDto GetById(int id);
        public ArbiterDto GetByUserId(int userId);
    }
    public class ArbiterService : IArbiterService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;
        public ArbiterService(TournamentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ArbiterDto>> GetAllArbitersAsync()
        {
            var allArbiters = await _dbContext.Arbiters.ToListAsync();
            var arbitersDtos = _mapper.Map<IEnumerable<ArbiterDto>>(allArbiters);

            return arbitersDtos;
        }
        public int CreateArbiter(CreateArbiterDto arbiterDto)
        {
            var arbiter = _mapper.Map<CreateArbiterDto, Arbiter>(arbiterDto);
            _dbContext.Arbiters.Add(arbiter);
            _dbContext.SaveChanges();

            return arbiter.Id;
        }

        public ArbiterDto GetById(int id)
        {
            var arbiter = _dbContext.Arbiters.FirstOrDefault(x => x.Id == id);
            if (arbiter == null)
            {
                throw new Exception("Arbiter not found");
            }
            var arbiterDto = _mapper.Map<ArbiterDto>(arbiter);
            return arbiterDto;
        }

        public ArbiterDto GetByUserId(int userId)
        {
            var arbiter = _dbContext.Arbiters.FirstOrDefault(x => x.UserId == userId);
            if (arbiter == null)
            {
                throw new Exception("Arbiter not found");
            }
            var arbiterDto = _mapper.Map<ArbiterDto>(arbiter);
            return arbiterDto;
        }
    }
}
