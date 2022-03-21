namespace CovidApp
{
    public interface IAddressRepository
    {
        Task<City> FindCityByName(string CityName);
        Task<District> FindDistrictByName(string DistirctName);
        Task<List<Address>> GetAllAddress();
        Task<Address> GetAddressById(int id);
        Task<List<City>> GetAllCity();
        Task<List<District>> GetAllDistricts();
        Task<Address> UpdateAddress(Address address);
        Task<Address> CreateAddress(Address address);
        Task<City> CreateCity(City city);
        Task<District> CreateDistrict(District district);
        Task<Address> DeleteAddress(int id);
     
    }
    
}