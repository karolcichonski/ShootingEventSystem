using Microsoft.AspNetCore.Mvc;
using ShootingEventSystemWebAPI.Models;
using ShootingEventSystemWebAPI.Services;

namespace ShootingEventSystemWebAPI.Controllers
{
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<AddressDto>> GetAll()
        {
            var addresses = _addressService.GetAllAddresses();
            
            return Ok(addresses);
        }

        [HttpGet("ById")]
        public ActionResult<AddressDto> GetById([FromQuery] int id)
        {
            var address = _addressService.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        public ActionResult<int> CreateAddress([FromBody] AddressDto addressDto)
        {
            if (addressDto == null)
            {
                return BadRequest();
            }
            var id = _addressService.CreateAddress(addressDto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpDelete]
        public ActionResult DeleteAddress([FromQuery] int id)
        {
            var address = _addressService.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            _addressService.DeleteAddress(id);
            return NoContent();
        }
    }
}
