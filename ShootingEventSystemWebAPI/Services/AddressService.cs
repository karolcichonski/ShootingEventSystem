using AutoMapper;
using ShootingEventSystemWebAPI.Entities;
using ShootingEventSystemWebAPI.Models;

namespace ShootingEventSystemWebAPI.Services
{
    public interface IAddressService
    {
        public IEnumerable<AddressDto> GetAllAddresses();
        public AddressDto GetById(int id);
        public int CreateAddress(AddressDto addressDto);
        public void DeleteAddress(int id);

    }
    public class AddressService: IAddressService
    {
        private readonly TournamentDbContext _dbContext;
        private readonly IMapper _mapper;
        public AddressService(TournamentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public IEnumerable<AddressDto> GetAllAddresses()
        {
            var allAddresses = _dbContext.Addresses.ToList();
            var addressesDtos = _mapper.Map<List<AddressDto>>(allAddresses);
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
