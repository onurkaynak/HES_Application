using Microsoft.AspNetCore.Mvc;

namespace CovidApp
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
           
        }
        [HttpGet("Getall")]
        public async Task<List<Address>> GetAllAddress()
        {
            return await _addressService.GetAllAddress();

        }
        [HttpGet("id")]
        public async Task<Address> GetAddressById(int id)
        {
            return await _addressService.GetAddressById(id);
        }

        [HttpGet("AllCity")]
        public async Task<List<City>> GetAllCity()
        {
            return await _addressService.GetAllCity();
        }
        [HttpGet("AllDistrict")]
        public async Task<List<District>> GetAllDistricts()
        {
            return await _addressService.GetAllDistricts();
        }
        [HttpPost("CreateAddress")]
        public async Task<Address> CreateAddress(Address address)
        {
            return await _addressService.CreateAddress(address);
        }
        [HttpPut]
        public async Task<Address> UpdateAddress(Address address)
        {
            return await _addressService.UpdateAddress(address);

        }
        [HttpPost("City")]
        public async Task<City> CreateCity(City city)
        {
            return await _addressService.CreateCity(city);
        }
         [HttpPost("District")]
        public async Task<District> CreateDistrict(District district)
        {
            return await _addressService.CreateDistrict(district);
        }
        [HttpDelete]
        public async Task<Address> DeleteAddress(int id)
        {
            return await _addressService.DeleteAddress(id);
        }

    }
}