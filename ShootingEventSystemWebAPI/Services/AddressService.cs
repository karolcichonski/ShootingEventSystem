using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface IAddressService
    {
        public Task<IEnumerable<AddressDto>> GetAllAddressesAsync();
        public AddressDto GetById(int id);
        public int CreateAddress(AddressDto addressDto);
        public void DeleteAddress(int id);

    }
    public class AddressService: IAddressService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressService> _logger;
        public AddressService(TournamentDbContext dbContext, IMapper mapper, ILogger<AddressService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public int CreateAddress(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();

            return address.Id;
        }

        public void DeleteAddress(int id)
        {
            _logger.LogWarning("Deleting address with id {id}", id);

            var adrressToRemove=_dbContext.Addresses.FirstOrDefault(x=>x.Id == id);
            if (adrressToRemove != null)
            {
                _dbContext.Addresses.Remove(adrressToRemove);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Address not found");
            }
        }

        public async Task<IEnumerable<AddressDto>> GetAllAddressesAsync()
        {
            var allAddresses = await _dbContext.Addresses.ToListAsync();
            var addressesDtos = _mapper.Map<IEnumerable<AddressDto>>(allAddresses);
            return addressesDtos;

        }

        public AddressDto GetById(int id)
        {
            var address = _dbContext.Addresses.FirstOrDefault(x => x.Id == id);
            if (address == null)
            {
                return null;
            }
            else
            {
                var addressDto = _mapper.Map<AddressDto>(address);
                return addressDto;
            }
        }
    }
}
