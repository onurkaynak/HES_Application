namespace CovidApp
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> CreateAddress(Address address)
        {
            return await _addressRepository.CreateAddress(address);
        }

        public async Task<City> CreateCity(City city)
        {
            var ExistCity = await _addressRepository.FindCityByName(city.Name);
            if (ExistCity == null)
            {
                return await _addressRepository.CreateCity(city);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<District> CreateDistrict(District district)
        {
            var ExistDistrict = await _addressRepository.FindDistrictByName(district.Name);
            if (ExistDistrict == null)
            {
                return await _addressRepository.CreateDistrict(district);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<Address> DeleteAddress(int id)
        {
            return await _addressRepository.DeleteAddress(id);
        }


        public async Task<Address> GetAddressById(int id)
        {
            return await _addressRepository.GetAddressById(id);
        }

        public async Task<List<Address>> GetAllAddress()
        {
            return await _addressRepository.GetAllAddress();
        }
        public async Task<List<City>> GetAllCity()
        {
            return await _addressRepository.GetAllCity();
        }

        public async Task<List<District>> GetAllDistricts()
        {
            return await _addressRepository.GetAllDistricts();


        }

        public async Task<Address> UpdateAddress(Address address)
        {
            var updateaddress = await _addressRepository.UpdateAddress(address);
            if (updateaddress != null)
            {
                return updateaddress;
            }
            return null;
        }
    }

}
